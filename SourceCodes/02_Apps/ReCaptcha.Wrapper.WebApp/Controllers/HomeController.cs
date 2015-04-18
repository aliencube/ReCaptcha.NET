using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aliencube.ReCaptcha.Wrapper.Interfaces;
using Aliencube.ReCaptcha.Wrapper.WebApp.Models;

namespace Aliencube.ReCaptcha.Wrapper.WebApp.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IReCaptchaV2Settings _settings;
        private readonly IReCaptchaV2 _reCaptcha;

        public HomeController(IReCaptchaV2Settings settings, IReCaptchaV2 reCaptcha)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            this._settings = settings;

            if (reCaptcha == null)
            {
                throw new ArgumentNullException("reCaptcha");
            }

            this._reCaptcha = reCaptcha;
        }

        public virtual async Task<ActionResult> Index()
        {
            var vm = new HomeIndexViewModel()
                     {
                         SiteKey = this._settings.SiteKey,
                         ApiUrl = this._settings.ApiUrl,
                     };
            return View(vm);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Index(HomeIndexViewModel form)
        {
            var result = await this._reCaptcha.SiteVerifyAsync(this._settings, this.Request.Form, this.Request.ServerVariables);

            var vm = form;
            vm.Success = result.Success;
            vm.ErrorCodes = result.ErrorCodes;
            return View(vm);
        }
    }
}