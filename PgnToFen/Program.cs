using PgnToFenCore;
using PgnToFenCore.Conversion;

namespace PgnToFen
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var parser = new ArgumentParser(args);

            if (!parser.CanParseArguments())
            {
                return;
            }

            try
            {
                FileCoordinator.PrepareFiles(parser.ParsedArguments);
            }
            catch (InvalidArgumentsException ex)
            {
                System.Console.WriteLine("There was a problem preparing files:");
                System.Console.WriteLine(ex.Message);
                return;
            }

            var conversionStrategy = new SaveFensToFileStrategy(parser.ParsedArguments.NewFilename);
            PgnToFenConverter.Convert(conversionStrategy, parser.ParsedArguments.SourceFilename);
        }
    }
}
