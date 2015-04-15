using Aliencube.ReCaptchaV2.Wrapper;
using Aliencube.ReCaptchaV2.Wrapper.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace Aliencube.ReCaptcha.Wrapper.Tests
{
    [TestFixture]
    public class ReCaptchaV2SettingsTest
    {
        private IReCaptchaV2Settings _settings;

        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Cleanup()
        {
            if (this._settings != null)
            {
                this._settings.Dispose();
            }
        }

        [Test]
        public void GivenConfig_Should_ReturnSettings()
        {
            this._settings = ReCaptchaV2Settings.CreateInstance();

            this._settings.Should().NotBeNull();
            this._settings.RequestUrl.Should().Be("https://www.google.com/recaptcha/api/siteverify");
            this._settings.ApiUrl.Should().Be("https://www.google.com/recaptcha/api.js");
            this._settings.SiteKey.Should().NotBeNullOrWhiteSpace();
            this._settings.SecretKey.Should().NotBeNullOrWhiteSpace();
        }
    }
}