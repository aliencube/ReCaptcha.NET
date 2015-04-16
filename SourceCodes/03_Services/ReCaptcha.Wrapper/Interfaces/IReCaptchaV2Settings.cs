using System;

namespace Aliencube.ReCaptcha.Wrapper.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>ReCaptchaV2Settings</c> class.
    /// </summary>
    public interface IReCaptchaV2Settings : IDisposable
    {
        /// <summary>
        /// Gets or sets the request URL.
        /// </summary>
        string RequestUrl { get; set; }

        /// <summary>
        /// Gets or sets the API URL used in JavaScript.
        /// </summary>
        string ApiUrl { get; set; }

        /// <summary>
        /// Gets or sets the site key for ReCaptcha.
        /// </summary>
        string SiteKey { get; set; }

        /// <summary>
        /// Gets or sets the secret key for ReCaptcha.
        /// </summary>
        string SecretKey { get; set; }
    }
}