using System;

namespace Aliencube.ReCaptcha.Wrapper.Mvc.Parameters
{
    /// <summary>
    /// This specifies JavaScript rendering options.
    /// </summary>
    /// <remarks>More details: https://developers.google.com/recaptcha/docs/display#auto_render</remarks>
    [Flags]
    public enum ApiJsRenderingOptions
    {
        /// <summary>
        /// Identifies no rendering option is defined.
        /// </summary>
        None = 0,

        /// <summary>
        /// Identifies asynchronous rendering option is defined.
        /// </summary>
        Async = 1 << 0,

        /// <summary>
        /// Identifies deer rendering option is defined.
        /// </summary>
        Defer = 1 << 1,
    }
}