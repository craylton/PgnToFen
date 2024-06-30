using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PgnToFenCore;

internal static class StringExtensions
{
    public static string RemovePgnHeaders(this string target) =>
        target.RemoveLinesWhere(line => line.IsPgnHeader());

    public static string RemoveComments(this string target) =>
        Regex.Replace(target.Trim(), @" ?{.*?}", string.Empty);

    public static string CleanMoveNumbers(this string target) =>
        target.Replace("...", ".");

    public static string RemoveEndingMarker(this string target)
    {
        if (target.EndsWith('*'))
            return target[..^1];
        return target[..^4];
    }

    private static string RemoveLinesWhere(this string target, Func<string, bool> predicate)
    {
        IEnumerable<string> allLines = target.Split('\n');
        IEnumerable<string> filteredLines = allLines.ExcludeWhere(predicate);
        return string.Join("\n", filteredLines);
    }

    private static bool IsPgnHeader(this string target) =>
        target.Trim().StartsWith('[') && target.Trim().EndsWith(']');
}
