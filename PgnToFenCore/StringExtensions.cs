using System;
using System.Collections.Generic;

namespace PgnToFenCore
{
    internal static class StringExtensions
    {
        public static string RemoveLinesWhere(this string target, Func<string, bool> predicate)
        {
            IEnumerable<string> filteredLines = target.Split('\n').ExcludeWhere(predicate);
            return string.Join("\n", filteredLines);
        }
    }
}
