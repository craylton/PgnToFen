using ilf.pgn;
using ilf.pgn.Data;

namespace PgnToFen
{
    public class PgnToFenConverter
    {
        public void Convert(ParsedArguments parsedArgs)
        {
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
