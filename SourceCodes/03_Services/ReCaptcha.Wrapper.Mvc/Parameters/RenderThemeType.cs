using System.Runtime.Serialization;

namespace Aliencube.ReCaptcha.Wrapper.Mvc.Parameters
{
    /// <summary>
    /// This specifies the theme type for the reCaptcha control.
    /// </summary>
    public enum RenderThemeType
    {
        /// <summary>
        /// Identifies no theme is defined.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Identifies the light theme.
        /// </summary>
        [EnumMember(Value = "light")]
        Light = 1,

        /// <summary>
        /// Identifies the dark theme.
        /// </summary>
        [EnumMember(Value = "dark")]
        Dark = 2,
    }
}