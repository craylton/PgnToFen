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
    }
}
