using System;
using System.IO;

namespace PgnToFen
{
    public class ArgumentParser
    {
        public ParsedArguments ParsedArguments { get; private set; }

        private ArgumentParser(string[] args)
        {
            var sourceFilename = GetSourceFilenameFromArgumentList(args);
            var newFilename = GetNewFilenameFromArgumentList(args);

            if (sourceFilename != null && newFilename is null)
            {
                newFilename = GetDefaultFenFileName(sourceFilename);
            }

            ParsedArguments = new ParsedArguments(sourceFilename, newFilename);
        }

        public static bool TryParseArguments(string[] args, out ParsedArguments parsedArgs)
        {
            var argsParser = new ArgumentParser(args);
            parsedArgs = argsParser.ParsedArguments;

            if (!argsParser.IsSourceFilenameValid(argsParser.ParsedArguments.SourceFilename))
            {
                return false;
            }

            if (File.Exists(argsParser.ParsedArguments.NewFilename))
            {
                if (argsParser.ShouldOverwriteNewFile(argsParser.ParsedArguments.NewFilename))
                {
                    File.Delete(argsParser.ParsedArguments.NewFilename);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsSourceFilenameValid(string filename)
        {
            if (filename is null)
            {
                Console.WriteLine("Please specify the filename of the PGN file with the --pgnfile flag.");
                return false;
            }

            if (!File.Exists(filename))
            {
                Console.WriteLine($"The file {filename} could not be found");
                Console.WriteLine("Please specify the filename of the PGN file with the --pgnfile flag.");
                return false;
            }

            return true;
        }

        private bool ShouldOverwriteNewFile(string filename)
        {
            Console.WriteLine($"{filename} already exists - do you want to overwrite? (y/n)");

            string shouldOverwrite = string.Empty;

            while (shouldOverwrite.IsYesResponse() && shouldOverwrite.IsNoResponse())
            {
                shouldOverwrite = Console.ReadLine();
            }

            return shouldOverwrite.IsYesResponse();
        }

        private string GetDefaultFenFileName(string sourceFilename) =>
            sourceFilename.ReplaceFileExtension("txt");

        private string GetNewFilenameFromArgumentList(string[] args) =>
            GetArgumentAfterMatch(args, arg => IsNewFilenameFlag(arg));

        private string GetSourceFilenameFromArgumentList(string[] args) =>
            GetArgumentAfterMatch(args, arg => IsSourceFilenameFlag(arg));

        private string GetArgumentAfterMatch(string[] args, Func<string, bool> predicate)
        {
            for (int i = 0; i < args.Length - 1; i++)
            {
                if (predicate(args[i]))
                {
                    return args[i + 1];
                }
            }

            return null;
        }

        private bool IsSourceFilenameFlag(string argument) =>
            argument == "-p" || argument == "--pgnfile";

        private bool IsNewFilenameFlag(string argument) =>
            argument == "-o" || argument == "--outputfile";
    }
}
