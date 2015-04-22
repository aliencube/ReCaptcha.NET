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

        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual async Task<ActionResult> Basic()
        {
            var vm = new HomeReCaptchaViewModel()
                         {
                             SiteKey = this._settings.SiteKey,
                             ApiUrl = this._settings.ApiUrl,
                         };
            return this.View(vm);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Basic(HomeReCaptchaViewModel form)
        {
            var result = await this.GetResponseAsync();

            var vm = form;
            vm.Success = result.Success;
            vm.ErrorCodes = result.ErrorCodes;
            return View(vm);
        }

        public virtual ActionResult Advanced()
        {
            var vm = new HomeReCaptchaViewModel()
                         {
                             SiteKey = this._settings.SiteKey,
                             ApiUrl = this._settings.ApiUrl,
                         };
            return this.View(vm);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Advanced(HomeReCaptchaViewModel form)
        {
            var result = await this.GetResponseAsync();

            var vm = form;
            vm.Success = result.Success;
            vm.ErrorCodes = result.ErrorCodes;
            return View(vm);
        }

        public virtual ActionResult Callback()
        {
            var vm = new HomeReCaptchaViewModel()
                         {
                             SiteKey = this._settings.SiteKey,
                             ApiUrl = this._settings.ApiUrl,
                         };
            return this.View(vm);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Callback(HomeReCaptchaViewModel form)
        {
            var result = await this.GetResponseAsync();

            var vm = form;
            vm.Success = result.Success;
            vm.ErrorCodes = result.ErrorCodes;
            return View(vm);
        }

        private async Task<ReCaptchaV2Response> GetResponseAsync()
        {
            var result = await this._reCaptcha.SiteVerifyAsync(this.Request.Form, this.Request.ServerVariables);
            return result;
        }
    }
}