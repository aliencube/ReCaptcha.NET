using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Aliencube.ReCaptcha.Wrapper.Mvc.Parameters
{
    /// <summary>
    /// This represents the parameter entity for reCaptcha rendering.
    /// </summary>
    /// <remarks>More details: https://developers.google.com/recaptcha/docs/display#render_param</remarks>
    public partial class RenderParameters
    {
        /// <summary>
        /// Gets or sets the site key.
        /// </summary>
        [JsonProperty(PropertyName = "data-sitekey")]
        public string SiteKey { get; set; }

        /// <summary>
        /// Gets or sets the theme.
        /// </summary>
        [JsonProperty(PropertyName = "data-theme")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RenderThemeType Theme { get; set; }

        /// <summary>
        /// Gets or sets the data type.
        /// </summary>
        [JsonProperty(PropertyName = "data-type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RenderDataType DataType { get; set; }

        /// <summary>
        /// Gets or sets the tab index.
        /// </summary>
        [JsonProperty(PropertyName = "data-tabindex")]
        public int TabIndex { get; set; }

        /// <summary>
        /// Gets or sets the callback.
        /// </summary>
        [JsonProperty(PropertyName = "data-callback")]
        public string Callback { get; set; }

        /// <summary>
        /// Gets or sets the expired callback.
        /// </summary>
        [JsonProperty(PropertyName = "data-expired-callback")]
        public string ExpiredCallback { get; set; }
    }
}