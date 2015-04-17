using System.Collections.Generic;

namespace Aliencube.ReCaptcha.Wrapper.WebApp.Models
{
    public class HomeIndexViewModel : ReCaptchaV2Request
    {
        public string Name { get; set; }

        public string SiteKey { get; set; }

        public string ApiUrl { get; set; }

        public bool Success { get; set; }

        public List<string> ErrorCodes { get; set; }
    }
}