using ChessDotNet;
using System.IO;

namespace PgnToFen
{
    public class FenSaver
    {
        public string Filename { get; }

        public FenSaver(string filename) => Filename = filename;

        public void SaveAllFens(GameData gameData)
        {
            var newGame = new ChessGame();

            using (var file = new StreamWriter(Filename, true))
            {
                SaveAllFensToStream(gameData, newGame, file);
            }
        }

        private void SaveAllFensToStream(GameData gameData, ChessGame game, StreamWriter stream)
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
