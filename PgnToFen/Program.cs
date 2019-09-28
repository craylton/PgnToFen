namespace PgnToFen
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (!ArgumentParser.TryParseArguments(args, out ParsedArguments parsedArgs))
            {
                return;
            }

            var converter = new PgnToFenConverter();
            converter.Convert(parsedArgs);
        }
    }
}
