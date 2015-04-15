using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Aliencube.ReCaptchaV2.Wrapper.Interfaces;

namespace Aliencube.ReCaptchaV2.Wrapper
{
    /// <summary>
    /// This represents the configuration section entity for ReCaptcha settings.
    /// </summary>
    public class ReCaptchaV2Settings : ConfigurationSection, IReCaptchaV2Settings
    {
        private bool _disposed;

        /// <summary>
        /// Gets or sets the request URL.
        /// </summary>
        [ConfigurationProperty("requestUrl", IsRequired = true)]
        public string RequestUrl
        {
            get { return (string)this["requestUrl"]; }
            set { this["requestUrl"] = value; }
        }

        /// <summary>
        /// Gets or sets the API URL used in JavaScript.
        /// </summary>
        [ConfigurationProperty("apiUrl", IsRequired = true)]
        public string ApiUrl
        {
            get { return (string)this["apiUrl"]; }
            set { this["apiUrl"] = value; }
        }

        /// <summary>
        /// Gets or sets the site key for ReCaptcha.
        /// </summary>
        [ConfigurationProperty("siteKey", IsRequired = true)]
        public string SiteKey
        {
            get { return (string)this["siteKey"]; }
            set { this["siteKey"] = value; }
        }

        /// <summary>
        /// Gets or sets the secret key for ReCaptcha.
        /// </summary>
        [ConfigurationProperty("secretKey", IsRequired = true)]
        public string SecretKey
        {
            get { return (string)this["secretKey"]; }
            set { this["secretKey"] = value; }
        }

        /// <summary>
        /// Creates a new instance of the <c>ReCaptchaV2Settings</c> class.
        /// </summary>
        /// <returns>Returns the new instance of the <c>ReCaptchaV2Settings</c> class.</returns>
        public static IReCaptchaV2Settings CreateInstance()
        {
            var settings = GetFromConverterSettings();
            if (settings != null)
            {
                return settings;
            }

            settings = GetFromAppSettings();
            return settings;
        }

        /// <summary>
        /// Gets the <c>ReCaptchaV2Settings</c> object from the reCaptchaV2Settings element.
        /// </summary>
        /// <returns>Returns the <c>ReCaptchaV2Settings</c> object.</returns>
        private static IReCaptchaV2Settings GetFromConverterSettings()
        {
            var settings = ConfigurationManager.GetSection("reCaptchaV2Settings") as IReCaptchaV2Settings;
            return settings;
        }

        /// <summary>
        /// Gets the <c>ReCaptchaV2Settings</c> object from the appSettings element.
        /// </summary>
        /// <returns>Returns the <c>ReCaptchaV2Settings</c> object.</returns>
        private static IReCaptchaV2Settings GetFromAppSettings()
        {
            var requestUrl = ConfigurationManager.AppSettings["RequestUrl"];
            var apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            var siteKey = ConfigurationManager.AppSettings["SiteKey"];
            var secretKey = ConfigurationManager.AppSettings["SecretKey"];

            var values = new List<string>() { requestUrl, apiUrl, siteKey, secretKey };

            if (values.Any(String.IsNullOrWhiteSpace))
            {
                return null;
            }

            var settings = new ReCaptchaV2Settings
                               {
                                   RequestUrl = requestUrl,
                                   ApiUrl = apiUrl,
                                   SiteKey = siteKey,
                                   SecretKey = secretKey,
                               };
            return settings;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}