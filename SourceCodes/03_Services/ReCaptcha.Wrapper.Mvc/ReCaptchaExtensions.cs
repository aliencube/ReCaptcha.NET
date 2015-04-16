using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aliencube.ReCaptcha.Wrapper.Mvc
{
    public static class ReCaptchaExtensions
    {
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, IEnumerable<string> classNames, string siteKey)
        {
            var className = String.Join(" ", classNames);
            return htmlHelper.ReCaptcha(className, siteKey);
        }

        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, string className, string siteKey)
        {
            var htmlAttributes = new Dictionary<string, object>()
                                     {
                                         { "class", className },
                                         { "data-sitekey", siteKey }
                                     };
            return htmlHelper.ReCaptcha(htmlAttributes);
        }

        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("div");
            builder.MergeAttributes(htmlAttributes);

            string result;
            if (builder.Attributes.ContainsKey("class") && builder.Attributes.TryGetValue("class", out result) && !result.Contains("g-recaptcha"))
            {
                builder.AddCssClass("g-recaptcha");
            }

            return builder.ToMvcHtmlString(TagRenderMode.Normal);
        }

        private static MvcHtmlString ToMvcHtmlString(this TagBuilder builder, TagRenderMode renderMode)
        {
            return new MvcHtmlString(builder.ToString(renderMode));
        }
    }
}