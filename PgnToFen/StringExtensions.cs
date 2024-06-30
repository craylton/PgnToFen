using System;
using System.IO;

namespace PgnToFen;

internal static class StringExtensions
{
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
