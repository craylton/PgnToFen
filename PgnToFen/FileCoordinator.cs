using System;
using System.IO;

namespace PgnToFen
{
    public class FileCoordinator
    {
        public void PrepareFiles(ParsedArguments parsedArguments)
        {
            ValidateSourceFilename(parsedArguments);
            ValidateOutputFilename(parsedArguments);
        }

        private void ValidateSourceFilename(ParsedArguments parsedArguments)
        {
            if (parsedArguments.SourceFilename is null)
            {
                parsedArguments.SourceFilename = GetSourceFilenameFromInput();
            }

            if (!File.Exists(parsedArguments.SourceFilename))
            {
                throw new InvalidArgumentsException($"The file {parsedArguments.SourceFilename} could not be found");
            }
        }

        private void ValidateOutputFilename(ParsedArguments parsedArguments)
        {
            if (parsedArguments.NewFilename is null)
            {
                parsedArguments.NewFilename = GetDefaultFenFileName(parsedArguments.SourceFilename);
            }

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

        private string GetSourceFilenameFromInput()
        {
            Console.WriteLine("Please specify the name of the file containing the PGN");
            return Console.ReadLine();
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
