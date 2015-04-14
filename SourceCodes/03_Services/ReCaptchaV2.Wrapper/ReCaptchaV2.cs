using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aliencube.ReCaptchaV2.Wrapper
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

            if (String.IsNullOrWhiteSpace(requestUrl) || String.IsNullOrWhiteSpace(apiUrl) || String.IsNullOrWhiteSpace(siteKey) || String.IsNullOrWhiteSpace(secretKey))
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

    /// <summary>
    /// This provides interfaces to the <c>ReCaptchaV2</c> class.
    /// </summary>
    public interface IReCaptchaV2 : IDisposable
    {
        /// <summary>
        /// Verifies the request.
        /// </summary>
        /// <param name="request"><c>ReCaptchaV2Request</c> object.</param>
        /// <returns>Returns <c>ReCaptchaV2Response</c> object.</returns>
        Task<ReCaptchaV2Response> SiteVerifyAsync(ReCaptchaV2Request request);
    }

    /// <summary>
    /// This represents the wrapper entity for ReCaptcha V2 API (https://google.com/recaptcha).
    /// </summary>
    public class ReCaptchaV2 : IReCaptchaV2
    {
        private readonly IReCaptchaV2Settings _settings;

        private bool _disposed;

        /// <summary>
        /// Initialises a new instance of the <c>ReCaptchaV2</c> class.
        /// </summary>
        /// <param name="settings"><c>ReCaptchaV2Settings</c> instance.</param>
        public ReCaptchaV2(IReCaptchaV2Settings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            this._settings = settings;
        }

        /// <summary>
        /// Verifies the request.
        /// </summary>
        /// <param name="request"><c>ReCaptchaV2Request</c> object.</param>
        /// <returns>Returns <c>ReCaptchaV2Response</c> object.</returns>
        public async Task<ReCaptchaV2Response> SiteVerifyAsync(ReCaptchaV2Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var responseBody = await this.GetResponseBodyAsync(request);
            var response = JsonConvert.DeserializeObject<ReCaptchaV2Response>(responseBody);
            return response;
        }

        /// <summary>
        /// Gets the response body as a JSON format asynchronously.
        /// </summary>
        /// <param name="request"><c>ReCaptchaV2Request</c> object.</param>
        /// <returns>Returns the response body as a JSON format.</returns>
        private async Task<string> GetResponseBodyAsync(ReCaptchaV2Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            string responseBody;
            using (var client = new HttpClient())
            {
                var requestBody = this.GetRequestBody(request);
                var content = new StringContent(requestBody, Encoding.UTF8, "application/x-www-form-urlencoded");

                var httpResponse = await client.PostAsync(this._settings.RequestUrl, content);
                responseBody = await httpResponse.Content.ReadAsStringAsync();
            }

            return responseBody;
        }

        /// <summary>
        /// Gets the request body.
        /// </summary>
        /// <param name="request"><c>ReCaptchaV2Request</c> object.</param>
        /// <returns>Returns the request body.</returns>
        private string GetRequestBody(ReCaptchaV2Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var requestBody = request.GetType()
                                     .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                     .ToDictionary(p => p.Name.ToLower(), p => (string)p.GetValue(request, null))
                                     .Flatten();
            return requestBody;
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

    public static class DictionaryExtensions
    {
        public static string Flatten<TKey, TValue>(this Dictionary<TKey, TValue> values)
        {
            var result = String.Join("&", values.Select(p => String.Format("{0}={1}", p.Key, p.Value)));
            return result;
        }
    }

    /// <summary>
    /// This represents the request entity for ReCaptcha V2.
    /// </summary>
    public class ReCaptchaV2Request
    {
        /// <summary>
        /// Gets or sets the secret key for ReCaptcha.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets the response token provided by ReCaptcha.
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Gets or sets the remote IP address.
        /// </summary>
        public string RemoteIp { get; set; }
    }

    /// <summary>
    /// This represents the response entity for ReCaptcha V2.
    /// </summary>
    public class ReCaptchaV2Response
    {
        /// <summary>
        /// Gets or sets the value that specifies whether the request was successful or not.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the list of error codes, if the request was not successful.
        /// </summary>
        public List<string> ErrorCodes { get; set; }
    }
}