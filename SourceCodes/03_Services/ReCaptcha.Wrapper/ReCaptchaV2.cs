using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Aliencube.ReCaptcha.Wrapper.Interfaces;
using Newtonsoft.Json;

namespace Aliencube.ReCaptcha.Wrapper
{
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
        /// Verifies the request asynchronously.
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
        public async Task<string> GetResponseBodyAsync(ReCaptchaV2Request request)
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
        public string GetRequestBody(ReCaptchaV2Request request)
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
}