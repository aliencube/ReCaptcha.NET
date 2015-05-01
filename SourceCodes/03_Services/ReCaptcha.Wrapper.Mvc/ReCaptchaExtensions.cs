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
        /// <param name="siteKey">reCaptcha site key.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, string siteKey)
        {
            if (String.IsNullOrWhiteSpace(siteKey))
            {
                throw new ArgumentNullException("siteKey");
            }

            var parameters = new RenderParameters() { SiteKey = siteKey };
            return htmlHelper.ReCaptcha(parameters, null);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="siteKey">reCaptcha site key.</param>
        /// <param name="htmlAttributes">List of HTML attributes.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, string siteKey, object htmlAttributes)
        {
            if (String.IsNullOrWhiteSpace(siteKey))
            {
                throw new ArgumentNullException("siteKey");
            }

            var parameters = new RenderParameters() { SiteKey = siteKey };
            return htmlHelper.ReCaptcha(parameters, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="siteKey">reCaptcha site key.</param>
        /// <param name="htmlAttributes">List of HTML attributes.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, string siteKey, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrWhiteSpace(siteKey))
            {
                throw new ArgumentNullException("siteKey");
            }

            var parameters = new RenderParameters() { SiteKey = siteKey };
            return htmlHelper.ReCaptcha(parameters, htmlAttributes);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="parameters"><c>ReCaptchaParameters</c> object.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, RenderParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            if (String.IsNullOrWhiteSpace(parameters.SiteKey))
            {
                throw new InvalidOperationException("SiteKey not found");
            }

            return htmlHelper.ReCaptcha(parameters, null);
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="parameters"><c>ReCaptchaParameters</c> object.</param>
        /// <param name="htmlAttributes">List of HTML attributes.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, RenderParameters parameters, object htmlAttributes)
        {
            return htmlHelper.ReCaptcha(parameters, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Renders the reCaptcha HTML control.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="htmlAttributes">List of HTML attributes.</param>
        /// <param name="parameters"><c>ReCaptchaParameters</c> object.</param>
        /// <returns>Returns the reCaptcha HTML control.</returns>
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, RenderParameters parameters, IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("div");

            if (parameters != null)
            {
                builder.MergeAttributes(parameters.ToDictionary<RenderParameters, string, object>());
            }

            if (htmlAttributes != null)
            {
                builder.MergeAttributes(htmlAttributes);
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