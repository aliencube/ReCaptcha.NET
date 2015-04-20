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
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, IEnumerable<string> classNames, string siteKey)
        {
            if (classNames == null)
            {
                throw new ArgumentNullException("classNames");
            }

            if (String.IsNullOrWhiteSpace(siteKey))
            {
                throw new ArgumentNullException("siteKey");
            }

            var className = String.Join(" ", classNames);
            return htmlHelper.ReCaptcha(className, siteKey);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="className">List of CSS class names.</param>
        /// <param name="siteKey">reCaptcha site key.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, string className, string siteKey)
        {
            if (String.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentNullException("siteKey");
            }

            if (String.IsNullOrWhiteSpace(siteKey))
            {
                throw new ArgumentNullException("siteKey");
            }

            var htmlAttributes = new Dictionary<string, object>()
                                     {
                                         { "class", className },
                                     };
            var parameters = new RenderParameters()
                                 {
                                     SiteKey = siteKey
                                 };
            return htmlHelper.ReCaptcha(htmlAttributes, parameters);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="htmlAttributes">List of HTML attributes.</param>
        /// <param name="parameters"><c>ReCaptchaParameters</c> object.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes, RenderParameters parameters = null)
        {
            if (htmlAttributes == null)
            {
                throw new ArgumentNullException("htmlAttributes");
            }

            var builder = new TagBuilder("div");
            builder.MergeAttributes(htmlAttributes);

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