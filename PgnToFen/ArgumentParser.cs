using System;
using System.IO;

namespace PgnToFen
{
    public class ArgumentParser
    {
        public string SourceFilename { get; private set; }
        public string NewFilename { get; private set; }

        public ArgumentParser(string[] args)
        {
            SourceFilename = GetSourceFilenameFromArgumentList(args);
            NewFilename = GetNewFilenameFromArgumentList(args);

            if (SourceFilename != null && NewFilename is null)
            {
                NewFilename = GetDefaultFenFileName(SourceFilename);
            }
        }

        public void DeleteExistingNewFile() => File.Delete(NewFilename);

        public bool NewFilenameAlreadyExists() => File.Exists(NewFilename);

        public bool IsSourceFilenameValid()
        {
            if (SourceFilename is null)
            {
                Console.WriteLine("Please specify the filename of the PGN file with the --pgnfile flag.");
                return false;
            }

            if (!File.Exists(SourceFilename))
            {
                Console.WriteLine($"The file {SourceFilename} could not be found");
                Console.WriteLine("Please specify the filename of the PGN file with the --pgnfile flag.");
                return false;
            }

            return true;
        }

        public bool ShouldOverwriteNewFile()
        {
            Console.WriteLine($"{NewFilename} already exists - do you want to overwrite? (y/n)");

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
