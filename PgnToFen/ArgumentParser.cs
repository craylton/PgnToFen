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
            for (int i = 0; i < args.Length; i++)
            {
                if (IsSourceFilenameFlag(args[i]))
                {
                    SourceFilename = args[i + 1];
                    i++;
                    continue;
                }

                if (IsNewFilenameFlag(args[i]))
                {
                    NewFilename = args[i + 1];
                    i++;
                    continue;
                }
            }

            if (SourceFilename != null && NewFilename is null)
            {
                NewFilename = GetDefaultFenFileName(SourceFilename);
            }
        }

        public void DeleteExistingNewFile() => File.Delete(NewFilename);

        private string GetDefaultFenFileName(string sourceFilename) =>
            sourceFilename.ReplaceFileExtension("txt");

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
            while (shouldOverwrite != "y" && shouldOverwrite != "n")
            {
                shouldOverwrite = Console.ReadLine();
            }

            return shouldOverwrite == "y";
        }

        private bool IsSourceFilenameFlag(string argument) =>
            argument == "-p" || argument == "--pgnfile";

        private bool IsNewFilenameFlag(string argument) =>
            argument == "-o" || argument == "--outputfile";
    }
}
