using System;
using Aliencube.ReCaptchaV2.Wrapper;
using Aliencube.ReCaptchaV2.Wrapper.Interfaces;
using FluentAssertions;
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
            this._reCaptcha = new ReCaptchaV2.Wrapper.ReCaptchaV2(this._settings);
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
        [TestCase("THIS_IS_SECRET_KEY", "THIS_IS_RESPONSE_KEY", "127.0.0.1")]
        public void GivenRequestValues_Should_ReturnRequestBody(string secret, string response, string remoteIp)
        {
            var request = new ReCaptchaV2Request() { Secret = secret, Response = response, RemoteIp = remoteIp };
            var requestBody = this._reCaptcha.GetRequestBody(request);
            requestBody.Should().Be(String.Format("secret={0}&response={1}&remoteip={2}", secret, response, remoteIp));
        }
    }
}