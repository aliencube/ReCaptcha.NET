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
        /// Renders the JavaScript control to render the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="src">JavaScript reference source.</param>
        /// <returns>Returns the JavaScript control to render the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptchaApiJs(this HtmlHelper htmlHelper, string src)
        {
            if (String.IsNullOrWhiteSpace(src))
            {
                throw new ArgumentNullException("src");
            }

            return htmlHelper.ReCaptchaApiJs(src, JsRenderingOptions.None);
        }

        /// <summary>
        /// Renders the JavaScript control to render the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="src">JavaScript reference source.</param>
        /// <param name="options"><c>JsRenderingOptions</c> enum value.</param>
        /// <returns>Returns the JavaScript control to render the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptchaApiJs(this HtmlHelper htmlHelper, string src, JsRenderingOptions options)
        {
            if (String.IsNullOrWhiteSpace(src))
            {
                throw new ArgumentNullException("src");
            }

            var htmlAttributes = new Dictionary<string, object>()
                                     {
                                         { "src", src },
                                     };
            return htmlHelper.ReCaptchaApiJs(htmlAttributes, options);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="htmlAttributes">List of HTML attributes.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptchaApiJs(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null)
            {
                throw new ArgumentNullException("htmlAttributes");
            }

            return htmlHelper.ReCaptchaApiJs(htmlAttributes, JsRenderingOptions.None);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="htmlAttributes">List of HTML attributes.</param>
        /// <param name="options"><c>JsRenderingOptions</c> enum value.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptchaApiJs(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes, JsRenderingOptions options)
        {
            if (htmlAttributes == null)
            {
                throw new ArgumentNullException("htmlAttributes");
            }

            if (options.HasFlag(JsRenderingOptions.Async))
            {
                var async = Convert.ToString(JsRenderingOptions.Async).ToLower();
                htmlAttributes.Add(async, async);
            }

            if (options.HasFlag(JsRenderingOptions.Defer))
            {
                var defer = Convert.ToString(JsRenderingOptions.Defer).ToLower();
                htmlAttributes.Add(defer, defer);
            }

            var builder = new TagBuilder("script");
            builder.MergeAttributes(htmlAttributes);

            return builder.ToMvcHtmlString(TagRenderMode.Normal);
        }
    }
}