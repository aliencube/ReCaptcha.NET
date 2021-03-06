using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Aliencube.ReCaptcha.Wrapper.Mvc.Parameters
{
    /// <summary>
    /// This represents the parameters entity to render api.js.
    /// </summary>
    /// <remarks>More details: https://developers.google.com/recaptcha/docs/display#js_param</remarks>
    public partial class ResourceParameters
    {
        /// <summary>
        /// Gets or sets the callback method name on load.
        /// </summary>
        [JsonProperty(PropertyName = "onload")]
        public string OnLoad { get; set; }

        /// <summary>
        /// Gets or sets the render option.
        /// </summary>
        [JsonProperty(PropertyName = "render")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WidgetRenderType Render { get; set; }

        /// <summary>
        /// Gets or sets the language code to display reCaptcha control.
        /// </summary>
        [JsonProperty(PropertyName = "hl")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WidgetLanguageCode LanguageCode { get; set; }
    }
}