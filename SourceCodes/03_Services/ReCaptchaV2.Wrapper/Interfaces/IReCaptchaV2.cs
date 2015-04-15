using System;
using System.Threading.Tasks;

namespace Aliencube.ReCaptchaV2.Wrapper.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>ReCaptchaV2</c> class.
    /// </summary>
    public interface IReCaptchaV2 : IDisposable
    {
        /// <summary>
        /// Verifies the request asynchronously.
        /// </summary>
        /// <param name="request"><c>ReCaptchaV2Request</c> object.</param>
        /// <returns>Returns <c>ReCaptchaV2Response</c> object.</returns>
        Task<ReCaptchaV2Response> SiteVerifyAsync(ReCaptchaV2Request request);

        /// <summary>
        /// Gets the response body as a JSON format asynchronously.
        /// </summary>
        /// <param name="request"><c>ReCaptchaV2Request</c> object.</param>
        /// <returns>Returns the response body as a JSON format.</returns>
        Task<string> GetResponseBodyAsync(ReCaptchaV2Request request);

        /// <summary>
        /// Gets the request body.
        /// </summary>
        /// <param name="request"><c>ReCaptchaV2Request</c> object.</param>
        /// <returns>Returns the request body.</returns>
        string GetRequestBody(ReCaptchaV2Request request);
    }
}