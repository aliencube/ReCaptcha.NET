using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Aliencube.ReCaptcha.Wrapper.Mvc.Extensions;
using Aliencube.ReCaptcha.Wrapper.Mvc.Parameters;

namespace Aliencube.ReCaptcha.Wrapper.Mvc
{
    /// <summary>
    /// This represents the entity for <c>ReCaptcha</c> extensions.
    /// </summary>
    /// <remarks>More details: https://developers.google.com/recaptcha/docs/display</remarks>
    public static class ReCaptchaExtensions
    {
        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="classNames">List of CSS class names.</param>
        /// <param name="siteKey">reCaptcha site key.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, IEnumerable<string> classNames = null, string siteKey = null)
        {
            string className = null;
            if (classNames != null)
            {
                className = String.Join(" ", classNames);
            }

            return htmlHelper.ReCaptcha(className, siteKey);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="className">List of CSS class names.</param>
        /// <param name="siteKey">reCaptcha site key.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, string className = null, string siteKey = null)
        {
            IDictionary<string, object> htmlAttributes = null;
            if (!String.IsNullOrWhiteSpace(className))
            {
                htmlAttributes = new Dictionary<string, object>()
                                     {
                                         { "class", className },
                                     };
            }

            RenderParameters parameters = null;
            if (!String.IsNullOrWhiteSpace(siteKey))
            {
                parameters = new RenderParameters()
                                 {
                                     SiteKey = siteKey
                                 };
            }

            return htmlHelper.ReCaptcha(htmlAttributes, parameters);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="htmlAttributes">List of HTML attributes.</param>
        /// <param name="parameters"><c>ReCaptchaParameters</c> object.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, object htmlAttributes, RenderParameters parameters)
        {
            return htmlHelper.ReCaptcha(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), parameters);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="htmlAttributes">List of HTML attributes.</param>
        /// <param name="parameters"><c>ReCaptchaParameters</c> object.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes, RenderParameters parameters)
        {
            var builder = new TagBuilder("div");

            if (htmlAttributes != null)
            {
                builder.MergeAttributes(htmlAttributes);
            }

            if (parameters != null)
            {
                builder.MergeAttributes(parameters.ToDictionary<RenderParameters, string, object>());
            }

            string result;
            if (!builder.Attributes.TryGetValue("class", out result))
            {
                result = "g-recaptcha";
                builder.AddCssClass(result);
            }

            if (!result.Contains("g-recaptcha"))
            {
                builder.AddCssClass("g-recaptcha");
            }

            return builder.ToMvcHtmlString(TagRenderMode.Normal);
        }
    }
}