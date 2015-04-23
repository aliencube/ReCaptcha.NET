using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Aliencube.ReCaptcha.Wrapper.Extensions;
using Aliencube.ReCaptcha.Wrapper.Mvc.Extensions;
using Aliencube.ReCaptcha.Wrapper.Mvc.Parameters;

namespace Aliencube.ReCaptcha.Wrapper.Mvc
{
    /// <summary>
    /// This represents the entity for <c>ReCaptcha</c> api.js extensions.
    /// </summary>
    /// <remarks>More details: https://developers.google.com/recaptcha/docs/display</remarks>
    public static class ReCaptchaApiJsExtensions
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

            return htmlHelper.ReCaptchaApiJs(src, ApiJsRenderingOptions.None);
        }

        /// <summary>
        /// Renders the JavaScript control to render the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="src">JavaScript reference source.</param>
        /// <param name="options"><c>JsRenderingOptions</c> enum value.</param>
        /// <returns>Returns the JavaScript control to render the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptchaApiJs(this HtmlHelper htmlHelper, string src, ApiJsRenderingOptions options)
        {
            if (String.IsNullOrWhiteSpace(src))
            {
                throw new ArgumentNullException("src");
            }

            return htmlHelper.ReCaptchaApiJs(src, options, null);
        }

        /// <summary>
        /// Renders the JavaScript control to render the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="src">JavaScript reference source.</param>
        /// <param name="options"><c>JsRenderingOptions</c> enum value.</param>
        /// <param name="parameters"><c>ResourceParameters</c> instance.</param>
        /// <returns>Returns the JavaScript control to render the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptchaApiJs(this HtmlHelper htmlHelper, string src, ApiJsRenderingOptions options, ResourceParameters parameters)
        {
            if (String.IsNullOrWhiteSpace(src))
            {
                throw new ArgumentNullException("src");
            }

            var htmlAttributes = new Dictionary<string, object>()
                                     {
                                         { "src", src },
                                     };
            return htmlHelper.ReCaptchaApiJs(htmlAttributes, options, parameters);
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

            return htmlHelper.ReCaptchaApiJs(htmlAttributes, ApiJsRenderingOptions.None);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="htmlAttributes">List of HTML attributes.</param>
        /// <param name="options"><c>JsRenderingOptions</c> enum value.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptchaApiJs(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes, ApiJsRenderingOptions options)
        {
            if (htmlAttributes == null)
            {
                throw new ArgumentNullException("htmlAttributes");
            }

            return htmlHelper.ReCaptchaApiJs(htmlAttributes, options, null);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="htmlAttributes">List of HTML attributes.</param>
        /// <param name="options"><c>JsRenderingOptions</c> enum value.</param>
        /// <param name="parameters"><c>ResourceParameters</c> instance.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptchaApiJs(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes, ApiJsRenderingOptions options, ResourceParameters parameters)
        {
            if (htmlAttributes == null)
            {
                throw new ArgumentNullException("htmlAttributes");
            }

            if (options.HasFlag(ApiJsRenderingOptions.Async))
            {
                var async = Convert.ToString(ApiJsRenderingOptions.Async).ToLower();
                htmlAttributes.Add(async, async);
            }

            if (options.HasFlag(ApiJsRenderingOptions.Defer))
            {
                var defer = Convert.ToString(ApiJsRenderingOptions.Defer).ToLower();
                htmlAttributes.Add(defer, defer);
            }

            var builder = new TagBuilder("script");
            builder.MergeAttributes(htmlAttributes);

            string src;
            if (parameters == null || !builder.Attributes.TryGetValue("src", out src))
            {
                return builder.ToMvcHtmlString(TagRenderMode.Normal);
            }

            src += src.Contains("?")
                       ? (src.EndsWith("?") ? null : "&")
                       : "?";
            src += parameters.ToDictionary<ResourceParameters, string, object>().Flatten();
            builder.Attributes["src"] = src;

            return builder.ToMvcHtmlString(TagRenderMode.Normal);
        }
    }
}