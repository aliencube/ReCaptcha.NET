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
        /// Verifies the request.
        /// </summary>
        /// <param name="request"><c>ReCaptchaV2Request</c> object.</param>
        /// <returns>Returns <c>ReCaptchaV2Response</c> object.</returns>
        ReCaptchaV2Response SiteVerify(ReCaptchaV2Request request);

        /// <summary>
        /// Verifies the request asynchronously.
        /// </summary>
        /// <param name="request"><c>ReCaptchaV2Request</c> object.</param>
        /// <returns>Returns <c>ReCaptchaV2Response</c> object.</returns>
        Task<ReCaptchaV2Response> SiteVerifyAsync(ReCaptchaV2Request request);
    }
}