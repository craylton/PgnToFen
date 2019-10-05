using System;
using System.IO;

namespace PgnToFen
{
    public class FileCoordinator
    {
        public void PrepareFiles(ParsedArguments parsedArguments)
        {
            if (!File.Exists(parsedArguments.SourceFilename))
            {
                throw new InvalidArgsException($"The file {parsedArguments.SourceFilename} could not be found");
            }

            if (parsedArguments.NewFilename is null)
            {
                parsedArguments.NewFilename = GetDefaultFenFileName(parsedArguments.SourceFilename);
            }

            if (parsedArguments.SourceFilename == parsedArguments.NewFilename)
            {
                throw new InvalidArgsException("Input PGN file and output file have the same name");
            }

            if (File.Exists(parsedArguments.NewFilename))
            {
                if (ShouldOverwriteNewFile(parsedArguments.NewFilename))
                {
                    File.Delete(parsedArguments.NewFilename);
                }
                else
                {
                    throw new InvalidArgsException($"{parsedArguments.NewFilename} already exists");
                }
            }
        }

        private bool ShouldOverwriteNewFile(string filename)
        {
            Console.WriteLine($"{filename} already exists - do you want to overwrite? (y/n)");

            string shouldOverwrite = string.Empty;

            while (!shouldOverwrite.IsYesResponse() && !shouldOverwrite.IsNoResponse())
            {
                shouldOverwrite = Console.ReadLine();
            }

            return shouldOverwrite.IsYesResponse();
        }

        private string GetDefaultFenFileName(string sourceFilename) =>
            sourceFilename.ReplaceFileExtension("txt");
    }
}
