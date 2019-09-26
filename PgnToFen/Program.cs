using ChessDotNet;
using System.IO;

namespace PgnToFen
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (!TryParseArguments(args, out ArgumentParser argsParser))
            {
                return;
            }

            var pgnFileReader = new ilf.pgn.PgnReader();
            ilf.pgn.Data.Database gameDb = pgnFileReader.ReadFromFile(argsParser.SourceFilename);

            foreach (var game in gameDb.Games)
            {
                GameData gameData = GameData.FromGame(game);
                SaveAllFens(gameData, argsParser.NewFilename);
            }
        }

        private static bool TryParseArguments(string[] args, out ArgumentParser argsParser)
        {
            argsParser = new ArgumentParser(args);

            if (!argsParser.IsSourceFilenameValid())
            {
                return false;
            }

            if (argsParser.NewFilenameAlreadyExists())
            {
                if (argsParser.ShouldOverwriteNewFile())
                {
                    argsParser.DeleteExistingNewFile();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static void SaveAllFens(GameData gameData, string filename)
        {
            var newGame = new ChessGame();

            using (var file = new StreamWriter(filename, true))
            {
                SaveAllFensToStream(gameData, newGame, file);
            }
        }

        private static void SaveAllFensToStream(GameData gameData, ChessGame game, StreamWriter stream)
        {
            SaveCurrentFen();

            foreach (var move in gameData.Moves)
            {
                game.MakeMove(move, true);
                SaveCurrentFen();
            }

            void SaveCurrentFen()
            {
                string fen = game.GetFen();
                stream.WriteLine(fen + '\t' + gameData.Result);
            }
        }
    }
}
