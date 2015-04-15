namespace Aliencube.ReCaptchaV2.Wrapper
{
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
}