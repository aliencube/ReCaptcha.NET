using System;
using System.Text;
using System.Web.Mvc;
using Aliencube.ReCaptcha.Wrapper.Mvc.Extensions;
using Aliencube.ReCaptcha.Wrapper.Mvc.Parameters;
using Newtonsoft.Json;

namespace Aliencube.ReCaptcha.Wrapper.Mvc
{
    /// <summary>
    /// This represents the entity for <c>ReCaptcha</c> callback extensions.
    /// </summary>
    /// <remarks>More details: https://developers.google.com/recaptcha/docs/display</remarks>
    public static class ReCaptchaCallbackJsExtensions
    {
        /// <summary>
        /// Renders the reCaptcha callback script.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="callback">Name of callback function.</param>
        /// <param name="elementId">Id of the placeholder element.</param>
        /// <param name="parameters"><c>RenderParameters</c> instance.</param>
        /// <returns>Returns the reCaptcha callback script.</returns>
        public static MvcHtmlString ReCaptchaCallbackJs(this HtmlHelper htmlHelper, string callback, string elementId, RenderParameters parameters)
        {
            if (String.IsNullOrWhiteSpace(callback))
            {
                throw new ArgumentNullException("callback");
            }

            if (String.IsNullOrWhiteSpace(elementId))
            {
                throw new ArgumentNullException("elementId");
            }

            var innerHtml = GetCallbackScript(callback, elementId, parameters);
            var builder = new TagBuilder("script")
                              {
                                  InnerHtml = innerHtml,
                              };
            return builder.ToMvcHtmlString(TagRenderMode.Normal);
        }

        /// <summary>
        /// Gets the callback script.
        /// </summary>
        /// <param name="callback">Name of callback function.</param>
        /// <param name="elementId">Id of the placeholder element.</param>
        /// <param name="parameters"><c>RenderParameters</c> instance.</param>
        /// <returns>Returns the callback script.</returns>
        private static string GetCallbackScript(string callback, string elementId, RenderParameters parameters)
        {
            if (String.IsNullOrWhiteSpace(callback))
            {
                throw new ArgumentNullException("callback");
            }

            if (String.IsNullOrWhiteSpace(elementId))
            {
                throw new ArgumentNullException("elementId");
            }

            var serialised = parameters == null
                                 ? null
                                 : JsonConvert.SerializeObject(parameters.ToDictionary<RenderParameters, string, object>())
                                              .Replace("\"data-", "\"");

            var sb = new StringBuilder();
            sb.AppendLine(String.Format("var {0} = function() {{", callback));
            sb.AppendLine(String.Format("grecaptcha.render(\"{0}\", {1});", elementId, serialised));
            sb.AppendLine("};");

            return sb.ToString();
        }
    }
}