using System.Web.Mvc;

namespace Aliencube.ReCaptcha.Wrapper.Mvc.Extensions
{
    /// <summary>
    /// This represents the entity for <c>TagBuilder</c> extensions.
    /// </summary>
    public static class TagBuilderExtensions
    {
        /// <summary>
        /// Converts HTML strings from <c>TagBuilder</c> instance.
        /// </summary>
        /// <param name="builder"><c>TagBuilder</c> instance.</param>
        /// <param name="renderMode"><c>TagRenderMode</c>.</param>
        /// <returns>Returns HTML strings converted.</returns>
        public static MvcHtmlString ToMvcHtmlString(this TagBuilder builder, TagRenderMode renderMode)
        {
            return new MvcHtmlString(builder.ToString(renderMode));
        }
    }
}