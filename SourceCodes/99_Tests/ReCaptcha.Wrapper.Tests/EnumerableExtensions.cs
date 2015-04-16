using System.Collections.Generic;
using System.Linq;

namespace Aliencube.ReCaptcha.Wrapper.Tests
{
    /// <summary>
    /// This represents the entity for <c>IEnumerable</c> extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Check whether the values is <c>null</c> or has zero length.
        /// </summary>
        /// <typeparam name="T"><c>IEmunerable{T}</c> type.</typeparam>
        /// <param name="values"><c>IEnumerable{T}</c> value.</param>
        /// <returns>Returns <c>True</c>, if the values is <c>null</c> or has zero length; otherwise returns <c>False</c>.</returns>
        public static bool IsNullOrZeroLength<T>(this IEnumerable<T> values)
        {
            return values == null || !values.Any();
        }
    }
}