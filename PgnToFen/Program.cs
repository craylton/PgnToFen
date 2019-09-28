using ilf.pgn;
using ilf.pgn.Data;

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

            var fenSaver = new FenSaver(parsedArgs.NewFilename);
            var pgnFileReader = new PgnReader();
            Database gameDb = pgnFileReader.ReadFromFile(parsedArgs.SourceFilename);

            foreach (var game in gameDb.Games)
            {
                GameData gameData = GameData.FromGame(game);
                fenSaver.SaveAllFens(gameData);
            }
        }
    }
}
