using System.Threading.Tasks;
using System.Web.Mvc;
using Aliencube.ReCaptcha.Wrapper.WebApp.Models;

namespace Aliencube.ReCaptcha.Wrapper.WebApp.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual async Task<ActionResult> Index()
        {
            var settings = ReCaptchaV2Settings.CreateInstance();
            var vm = new HomeIndexViewModel()
                     {
                         SiteKey = settings.SiteKey,
                         ApiUrl = settings.ApiUrl,
                     };
            return View(vm);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Index(HomeIndexViewModel form)
        {
            var settings = ReCaptchaV2Settings.CreateInstance();
            var vm = form;

            var request = vm as ReCaptchaV2Request;
            request.Secret = settings.SecretKey;
            using (var reCaptcha = new ReCaptchaV2(settings))
            {
                var result = await reCaptcha.SiteVerifyAsync(request);
                vm.Success = result.Success;
                vm.ErrorCodes = result.ErrorCodes;
            }
            return View(vm);
        }
    }
}