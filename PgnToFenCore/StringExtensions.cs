using System;
using System.Collections.Generic;

namespace PgnToFenCore
{
    internal static class StringExtensions
    {
        public static string RemovePgnHeaders(this string target) =>
            target.RemoveLinesWhere(line => line.Contains('['));

        public static string RemoveLinesWhere(this string target, Func<string, bool> predicate)
        {
            IEnumerable<string> allLines = target.Split('\n');
            IEnumerable<string> filteredLines = allLines.ExcludeWhere(predicate);
            return string.Join("\n", filteredLines);
        }
    }
}
