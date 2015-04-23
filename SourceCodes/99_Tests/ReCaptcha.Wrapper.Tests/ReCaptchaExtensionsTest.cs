using System;
using System.Web.Mvc;
using Aliencube.ReCaptcha.Wrapper.Mvc;
using Aliencube.ReCaptcha.Wrapper.Mvc.Parameters;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Aliencube.ReCaptcha.Wrapper.Tests
{
    [TestFixture]
    public class ReCaptchaExtensionsTest
    {
        private HtmlHelper _htmlHelper;

        [SetUp]
        public void Init()
        {
            var viewContext = Substitute.For<ViewContext>();
            var viewDataContainer = Substitute.For<IViewDataContainer>();
            this._htmlHelper = new HtmlHelper(viewContext, viewDataContainer);
        }

        [TearDown]
        public void Cleanup()
        {
            this._htmlHelper = null;
        }

        [Test]
        [TestCase("class1,class2", "YOUR_SITE_KEY")]
        [TestCase("class1 class2", "YOUR_SITE_KEY")]
        [TestCase(null, "YOUR_SITE_KEY")]
        public void GetReCaptchaHtml_GivenClassNamesAndSiteKey_ReturnReCaptchaHtml(string className, string siteKey)
        {
            MvcHtmlString reCaptcha;
            if (String.IsNullOrWhiteSpace(className) || !className.Contains(","))
            {
                reCaptcha = this._htmlHelper.ReCaptcha(className, siteKey);
            }
            else
            {
                var classNames = className.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
                reCaptcha = this._htmlHelper.ReCaptcha(classNames, siteKey);
            }

            if (!String.IsNullOrWhiteSpace(className))
            {
                reCaptcha.ToHtmlString()
                         .Should()
                         .MatchRegex("class=.+" + className.Replace(",", " "))
                         .And.Contain("g-recaptcha");
            }
            reCaptcha.ToHtmlString()
                     .Should()
                     .Contain(String.Format("data-sitekey=\"{0}\"", siteKey));
        }

        [Test]
        [TestCase("source", ApiJsRenderingOptions.Async | ApiJsRenderingOptions.Defer, "onLoadCallback", "explicit")]
        public void GetReCaptchaApiJs_GivenSrcAndOptionsAndParameters_Should_ReturnReCaptchaApiJsHtml(string src, ApiJsRenderingOptions options, params string[] parameters)
        {
            WidgetRenderType resultRenderType;
            var resourceParameters = new ResourceParameters()
                                         {
                                             OnLoad = parameters[0],
                                             Render = Enum.TryParse(parameters[1], true, out resultRenderType) ? resultRenderType : WidgetRenderType.Unknown,
                                         };
            var reCaptchaApiJs = this._htmlHelper.ReCaptchaApiJs(src, options, resourceParameters);
            if (options.HasFlag(ApiJsRenderingOptions.Async))
            {
                reCaptchaApiJs.ToHtmlString().Should().Contain("async");
            }
            if (options.HasFlag(ApiJsRenderingOptions.Defer))
            {
                reCaptchaApiJs.ToHtmlString().Should().Contain("defer");
            }
            reCaptchaApiJs.ToHtmlString().Should().MatchRegex("src=.+" + src);
            reCaptchaApiJs.ToHtmlString().Should().Contain("onload=" + parameters[0]);
            reCaptchaApiJs.ToHtmlString().Should().Contain("render=" + parameters[1]);
        }

        [Test]
        [TestCase("onLoadCallback", "recaptcha", "YOUR_SITE_KEY")]
        public void GetReCaptchaCallbackJs_GivenCallbackNameAndElementIdAndParameters_ShouldReturnReCaptchaCallbackJsHtml(string callback, string elementId, string siteKey)
        {
            var renderParameters = new RenderParameters() { SiteKey = siteKey };
            var reCaptchaCallbackJs = this._htmlHelper.ReCaptchaCallbackJs(callback, elementId, renderParameters);
            reCaptchaCallbackJs.ToHtmlString().Should().Contain(String.Format("var {0} = function()", callback));
            reCaptchaCallbackJs.ToHtmlString().Should().Contain(String.Format("\"{0}\"", elementId));
            reCaptchaCallbackJs.ToHtmlString().Should().Contain(String.Format("\"sitekey\":\"{0}\"", siteKey));
        }
    }
}