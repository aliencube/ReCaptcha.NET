using System.Collections.Generic;

namespace Aliencube.ReCaptcha.Wrapper.WebApp.Models
{
    /// <summary>
    /// This represents the view model entity for Home/Index.
    /// </summary>
    public class HomeIndexViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the site key value.
        /// </summary>
        public string SiteKey { get; set; }

        /// <summary>
        /// Gets or sets the reCaptcha API URL.
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// Gets or sets the value that specifies whether the reCaptcha validation was successful or not.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the list of error codes when the reCaptcha validation has failed.
        /// </summary>
        public List<string> ErrorCodes { get; set; }
    }
}