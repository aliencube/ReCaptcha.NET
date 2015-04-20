namespace Aliencube.ReCaptcha.Wrapper.Mvc.Parameters
{
    /// <summary>
    /// This specifies the reCaptcha control to render explicitly.
    /// </summary>
    /// <remarks>More details: https://developers.google.com/recaptcha/docs/display#js_param</remarks>
    public enum WidgetRenderType
    {
        /// <summary>
        /// Identifies no rendering type is defined.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Identifies the widget is rendered onload.
        /// </summary>
        Onload = 1,

        /// <summary>
        /// Identifies the widget is rendered explicitly.
        /// </summary>
        Explicit = 2,
    }
}