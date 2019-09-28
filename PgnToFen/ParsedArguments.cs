namespace PgnToFen
{
    public class ParsedArguments
    {
        public string SourceFilename { get; }
        public string NewFilename { get; }

        public ParsedArguments(string sourceFilename, string newFilename) => 
            (SourceFilename, NewFilename) = (sourceFilename, newFilename);
    }
}
