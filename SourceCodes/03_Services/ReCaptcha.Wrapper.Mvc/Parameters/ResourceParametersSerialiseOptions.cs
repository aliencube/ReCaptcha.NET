using System;

namespace Aliencube.ReCaptcha.Wrapper.Mvc.Parameters
{
    /// <summary>
    /// This represents the parameters entity to render api.js.
    /// </summary>
    /// <remarks>More details: https://developers.google.com/recaptcha/docs/display#js_param</remarks>
    public partial class ResourceParameters
    {
        /// <summary>
        /// Checks whether the <c>OnLoad</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>OnLoad</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeOnLoad()
        {
            return !String.IsNullOrWhiteSpace(this.OnLoad);
        }

        /// <summary>
        /// Checks whether the <c>Render</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>Render</c> property is other than <c>WidgetRenderType.Unknown</c>; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeRender()
        {
            return this.Render != WidgetRenderType.Unknown;
        }

        /// <summary>
        /// Checks whether the <c>LanguageCode</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>LanguageCode</c> property is other than <c>WidgetLanguageCode.Unknown</c>; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeLanguageCode()
        {
            return this.LanguageCode != WidgetLanguageCode.Unknown;
        }
    }
}