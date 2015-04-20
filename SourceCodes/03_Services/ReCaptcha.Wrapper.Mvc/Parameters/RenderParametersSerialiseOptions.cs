using System;

namespace Aliencube.ReCaptcha.Wrapper.Mvc.Parameters
{
    /// <summary>
    /// This represents the parameter entity for reCaptcha rendering.
    /// </summary>
    /// <remarks>More details: https://developers.google.com/recaptcha/docs/display#render_param</remarks>
    public partial class RenderParameters
    {
        /// <summary>
        /// Checks whether the <c>Theme</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>Theme</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeTheme()
        {
            return this.Theme != RenderThemeType.Unknown;
        }

        /// <summary>
        /// Checks whether the <c>DataType</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>DataType</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeDataType()
        {
            return this.DataType != RenderDataType.Unknown;
        }

        /// <summary>
        /// Checks whether the <c>TabIndex</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>TabIndex</c> property is not zero (0); otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeTabIndex()
        {
            return this.TabIndex != 0;
        }

        /// <summary>
        /// Checks whether the <c>Callback</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>Callback</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeCallback()
        {
            return !String.IsNullOrWhiteSpace(this.Callback);
        }

        /// <summary>
        /// Checks whether the <c>ExpiredCallback</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>ExpiredCallback</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeExpiredCallback()
        {
            return !String.IsNullOrWhiteSpace(this.ExpiredCallback);
        }
    }
}