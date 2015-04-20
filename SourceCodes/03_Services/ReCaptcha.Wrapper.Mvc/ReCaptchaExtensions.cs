using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aliencube.ReCaptcha.Wrapper.Mvc
{
    /// <summary>
    /// This represents the entity for <c>ReCaptcha</c> extensions.
    /// </summary>
    public static partial class ReCaptchaExtensions
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
            var parameters = new ReCaptchaParameters()
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
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes, ReCaptchaParameters parameters = null)
        {
            if (htmlAttributes == null)
            {
                throw new ArgumentNullException("htmlAttributes");
            }

            var builder = new TagBuilder("div");
            builder.MergeAttributes(htmlAttributes);

            if (parameters != null)
            {
                builder.MergeAttributes(parameters.ToDictionary<string, object>());
            }

            string result;
            if (builder.Attributes.ContainsKey("class") && builder.Attributes.TryGetValue("class", out result) && !result.Contains("g-recaptcha"))
            {
                builder.AddCssClass("g-recaptcha");
            }

            return builder.ToMvcHtmlString(TagRenderMode.Normal);
        }

        /// <summary>
        /// Converts HTML strings from <c>TagBuilder</c> instance.
        /// </summary>
        /// <param name="builder"><c>TagBuilder</c> instance.</param>
        /// <param name="renderMode"><c>TagRenderMode</c>.</param>
        /// <returns>Returns HTML strings converted.</returns>
        private static MvcHtmlString ToMvcHtmlString(this TagBuilder builder, TagRenderMode renderMode)
        {
            return new MvcHtmlString(builder.ToString(renderMode));
        }
    }
}