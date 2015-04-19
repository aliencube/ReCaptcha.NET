using System;

namespace Aliencube.ReCaptcha.Wrapper.Mvc
{
    /// <summary>
    /// This specifies JavaScript rendering options.
    /// </summary>
    [Flags]
    public enum JsRenderingOptions
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