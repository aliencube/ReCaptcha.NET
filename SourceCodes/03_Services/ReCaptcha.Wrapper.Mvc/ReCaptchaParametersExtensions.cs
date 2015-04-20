using System.Collections.Generic;
using Newtonsoft.Json;

namespace Aliencube.ReCaptcha.Wrapper.Mvc
{
    public static class ReCaptchaParametersExtensions
    {
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this ReCaptchaParameters value)
        {
            var serialised = JsonConvert.SerializeObject(value);
            var deserialised = JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(serialised);
            return deserialised;
        }
    }
}