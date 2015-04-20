using System.Runtime.Serialization;

namespace Aliencube.ReCaptcha.Wrapper.Mvc.Parameters
{
    /// <summary>
    /// This specifies the data type for reCaptcha control.
    /// </summary>
    public enum RenderDataType
    {
        /// <summary>
        /// Identifies no data type is defined.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Identifies the image data type.
        /// </summary>
        [EnumMember(Value = "image")]
        Image = 1,

        /// <summary>
        /// Identifies the audio data type.
        /// </summary>
        [EnumMember(Value = "audio")]
        Audio = 2,
    }
}