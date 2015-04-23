using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Aliencube.ReCaptcha.Wrapper.Interfaces;
using Aliencube.ReCaptcha.Wrapper.Tests.Extensions;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Aliencube.ReCaptcha.Wrapper.Tests
{
    [TestFixture]
    public class ReCaptchaV2Test
    {
        private IReCaptchaV2Settings _settings;
        private IReCaptchaV2 _reCaptcha;

        [SetUp]
        public void Init()
        {
            this._settings = ReCaptchaV2Settings.CreateInstance();
        }

        [TearDown]
        public void Cleanup()
        {
            if (this._reCaptcha != null)
            {
                this._reCaptcha.Dispose();
            }

            if (this._settings != null)
            {
                this._settings.Dispose();
            }
        }

        [Test]
        [TestCase("[YOUR_SECRET_KEY]", "YOUR_RESPONSE_KEY", "127.0.0.1")]
        public void GetReCaptchaV2Request_GivenFormAndServerVariables_Should_ReturnReCaptchaV2Request(string secretKey, string responseKey, string remoteIp)
        {
            var form = new NameValueCollection() { { "g-recaptcha-response", responseKey } };
            var serverVariables = new NameValueCollection() { { "REMOTE_ADDR", remoteIp } };

            this._reCaptcha = new ReCaptchaV2(this._settings);
            var request = this._reCaptcha.GetReCaptchaV2Request(form, serverVariables);
            request.Secret.Should().Be(secretKey);
            request.Response.Should().Be(responseKey);
            request.RemoteIp.Should().Be(remoteIp);
        }

        [Test]
        [TestCase("THIS_IS_SECRET_KEY", "THIS_IS_RESPONSE_KEY", "127.0.0.1")]
        public void GetRequestBody_GivenRequestValues_Should_ReturnRequestBody(string secretKey, string responseKey, string remoteIp)
        {
            var request = new ReCaptchaV2Request() { Secret = secretKey, Response = responseKey, RemoteIp = remoteIp };

            this._reCaptcha = Substitute.For<ReCaptchaV2>(this._settings);

            var requestBody = this._reCaptcha.GetRequestBody(request);
            requestBody.Should().Be(String.Format("secret={0}&response={1}&remoteip={2}", secretKey, responseKey, remoteIp));
        }

        [Test]
        [TestCase("THIS_IS_SECRET_KEY", "THIS_IS_RESPONSE_KEY", "127.0.0.1", true)]
        [TestCase("THIS_IS_SECRET_KEY", "THIS_IS_RESPONSE_KEY", "127.0.0.1", false, "missing-input-secret", "invalid-input-secret")]
        [TestCase("THIS_IS_SECRET_KEY", "THIS_IS_RESPONSE_KEY", "127.0.0.1", false, "missing-input-secret", "invalid-input-secret", "missing-input-response", "invalid-input-response")]
        public async void SiteVerifyAsync_GivenResponseBody_Should_ReturnReCaptchaV2Response(string secretKey, string responseKey, string remoteIp, bool success, params string[] errorCodes)
        {
            var request = new ReCaptchaV2Request() { Secret = secretKey, Response = responseKey, RemoteIp = remoteIp };
            var responseBody = String.Format("{{ \"success\": {0}, \"error-codes\": {1} }}",
                                             success.ToString().ToLower(),
                                             errorCodes.IsNullOrZeroLength() ? "null" : "[" + String.Join(",", errorCodes.Select(p => "\"" + p + "\"")) + "]");
            var result = Task.FromResult(responseBody);

            this._reCaptcha = Substitute.ForPartsOf<ReCaptchaV2>(this._settings);
            this._reCaptcha.When(p => p.GetResponseBodyAsync(Arg.Is(request))).DoNotCallBase();
            this._reCaptcha.GetResponseBodyAsync(Arg.Is(request)).Returns(result);

            var response = await this._reCaptcha.SiteVerifyAsync(request);
            response.Success.Should().Be(success);
            if (errorCodes.IsNullOrZeroLength())
            {
                response.ErrorCodes.Should().BeNullOrEmpty();
            }
            else
            {
                response.ErrorCodes.Should().Contain(errorCodes)
                                   .And.HaveCount(errorCodes.Length);
            }
        }
    }
}