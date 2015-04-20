using System.Collections.Generic;
using Aliencube.ReCaptcha.Wrapper.Mvc.Parameters;
using Newtonsoft.Json;

namespace Aliencube.ReCaptcha.Wrapper.Mvc.Extensions
{
    /// <summary>
    /// This represents the extension class for the <c>RenderParameters</c> class.
    /// </summary>
    public static class RenderParametersExtensions
    {
        /// <summary>
        /// Converts the <c>RenderParameters</c> instance to <c>Dictionary{TKey, TValue}</c>.
        /// </summary>
        /// <typeparam name="TKey">Key type parameter.</typeparam>
        /// <typeparam name="TValue">Value type parameter.</typeparam>
        /// <param name="value"><c>RenderParameters</c> instance.</param>
        /// <returns>Returns <c>Dictionary{TKey, TValue}</c> object converted.</returns>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this RenderParameters value)
        {
            var serialised = JsonConvert.SerializeObject(value);
            var deserialised = JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(serialised);
            return deserialised;
        }
    }
}