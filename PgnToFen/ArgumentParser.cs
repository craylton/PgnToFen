using NDesk.Options;
using System;

namespace PgnToFen
{
    internal class ArgumentParser
    {
        private readonly OptionSet parser;

        public string[] RawArgs { get; }
        public ParsedArguments ParsedArguments { get; }

        public ArgumentParser(string[] args)
        {
            RawArgs = args;
            ParsedArguments = new ParsedArguments();

            parser = new OptionSet()
            {
                {
                    "p|pgnfile=",
                    "the filename of the {PGNFILE} to load.",
                    filename => ParsedArguments.SourceFilename = filename
                },
                {
                    "o|output=",
                    "the filename of the {OUTPUT} file.",
                    filename => ParsedArguments.NewFilename = filename
                }
            };
        }

        public bool CanParseArguments()
        {
            try
            {
                parser.Parse(RawArgs);
            }
            catch (OptionException e)
            {
                Console.Write("There was a problem parsing arguments: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try '--help' for more information.");
                return false;
            }

            if (ParsedArguments.SourceFilename is null)
            {
                Console.WriteLine("Please specify the filename of the PGN file with the --pgnfile flag.");
                return false;
            }

            return true;
        }
    }
}
