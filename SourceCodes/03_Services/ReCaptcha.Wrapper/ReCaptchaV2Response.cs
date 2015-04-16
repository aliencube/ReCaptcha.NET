using System.Collections.Generic;
using Newtonsoft.Json;

namespace Aliencube.ReCaptcha.Wrapper
{
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
        [JsonProperty(PropertyName = "error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}