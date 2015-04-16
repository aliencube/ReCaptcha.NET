using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliencube.ReCaptcha.Wrapper
{
    /// <summary>
    /// This represents the entity for <c>Dictionary</c> extensions.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Flattens key/value pairs.
        /// </summary>
        /// <typeparam name="TKey">Key type parameter.</typeparam>
        /// <typeparam name="TValue">Value type parameter.</typeparam>
        /// <param name="values"><c>Dictionary</c> object.</param>
        /// <returns>Returns the flattened key/value pairs.</returns>
        public static string Flatten<TKey, TValue>(this Dictionary<TKey, TValue> values)
        {
            var result = String.Join("&", values.Select(p => String.Format("{0}={1}", p.Key, p.Value)));
            return result;
        }
    }
}