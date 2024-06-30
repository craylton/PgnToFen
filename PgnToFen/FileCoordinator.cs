using System;
using System.IO;

namespace PgnToFen;

public class FileCoordinator
{
    public static void PrepareFiles(ParsedArguments parsedArguments)
    {
        ValidateSourceFilename(parsedArguments);
        ValidateOutputFilename(parsedArguments);
    }

    private static void ValidateSourceFilename(ParsedArguments parsedArguments)
    {
        parsedArguments.SourceFilename ??= GetSourceFilenameFromInput();

        if (!File.Exists(parsedArguments.SourceFilename))
        {
            throw new InvalidArgumentsException($"The file {parsedArguments.SourceFilename} could not be found");
        }
    }

    private static void ValidateOutputFilename(ParsedArguments parsedArguments)
    {
        parsedArguments.NewFilename ??= GetDefaultFenFileName(parsedArguments.SourceFilename);

        if (parsedArguments.SourceFilename == parsedArguments.NewFilename)
        {
            throw new InvalidArgumentsException("Input PGN file and output file have the same name");
        }

        if (File.Exists(parsedArguments.NewFilename))
        {
            if (ShouldOverwriteNewFile(parsedArguments.NewFilename))
            {
                File.Delete(parsedArguments.NewFilename);
            }
            else
            {
                throw new InvalidArgumentsException($"{parsedArguments.NewFilename} already exists");
            }
        }
    }

    private static string GetSourceFilenameFromInput()
    {
        Console.WriteLine("Please specify the name of the file containing the PGN");
        return Console.ReadLine();
    }

    private static bool ShouldOverwriteNewFile(string filename)
    {
        Console.WriteLine($"{filename} already exists - do you want to overwrite? (y/n)");

        string shouldOverwrite = string.Empty;

        while (!shouldOverwrite.IsYesResponse() && !shouldOverwrite.IsNoResponse())
        {
            shouldOverwrite = Console.ReadLine();
        }

        return shouldOverwrite.IsYesResponse();
    }

    private static string GetDefaultFenFileName(string sourceFilename) =>
        sourceFilename.ReplaceFileExtension("txt");
}
