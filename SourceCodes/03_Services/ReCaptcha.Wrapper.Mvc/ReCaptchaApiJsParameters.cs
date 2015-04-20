namespace Aliencube.ReCaptcha.Wrapper.Mvc
{
    /// <summary>
    /// This represents the parameters entity to render api.js.
    /// </summary>
    public class ReCaptchaApiJsParameters
    {
        /// <summary>
        /// Gets or sets the callback method name on load.
        /// </summary>
        public string OnLoad { get; set; }

        /// <summary>
        /// Gets or sets the render option.
        /// </summary>
        public WidgetRenderType Render { get; set; }

        /// <summary>
        /// Gets or sets the language code to display reCaptcha control.
        /// </summary>
        public LanguageCode LanguageCode { get; set; }
    }
}