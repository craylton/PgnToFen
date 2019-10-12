using PgnToFenCore;
using PgnToFenCore.Conversion;

namespace PgnToFen
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var parser = new ArgumentParser(args);
            var fileCoordinator = new FileCoordinator();

            if (!parser.CanParseArguments())
            {
                return;
            }

            try
            {
                fileCoordinator.PrepareFiles(parser.ParsedArguments);
            }
            catch (InvalidArgsException ex)
            {
                System.Console.WriteLine("There was a problem preparing files:");
                System.Console.WriteLine(ex.Message);
                return;
            }

            var converter = new PgnToFenConverter();
            var conversionStrategy = new SaveFensToFileStrategy(parser.ParsedArguments.NewFilename);
            converter.Convert(conversionStrategy, parser.ParsedArguments.SourceFilename);
        }
    }
}
