using System;
using System.Collections.Generic;
using System.Linq;

namespace PgnToFenCore
{
    internal static class IEnumerableExtensions
    {
        public static IEnumerable<T> ExcludeWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate) =>
            source.Except(source.Where(predicate));
    }
}
