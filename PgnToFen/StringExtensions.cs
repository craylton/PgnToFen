using System;
using System.Collections.Generic;
using System.IO;

namespace PgnToFen
{
    public static class StringExtensions
    {
        public static string RemoveLinesWhere(this string target, Func<string, bool> predicate)
        {
            IEnumerable<string> filteredLines = target.Split('\n').ExcludeWhere(predicate);
            return string.Join("\n", filteredLines);
        }

        public static string ReplaceFileExtension(this string filename, string newExtension)
        {
            var extension = new FileInfo(filename).Extension;
            return filename.Replace(extension, $".{newExtension}");
        }

        public static bool IsYesResponse(this string input) =>
            input.EqualsIgnoreCase("y") || input.EqualsIgnoreCase("yes");

        public static bool IsNoResponse(this string input) =>
            input.EqualsIgnoreCase("n") || input.EqualsIgnoreCase("no");

        private static bool EqualsIgnoreCase(this string input, string compareString) =>
            input.Equals(compareString, StringComparison.InvariantCultureIgnoreCase);
    }
}
