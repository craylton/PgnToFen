using ChessDotNet;
using ilf.pgn.Data;
using System.Collections.Generic;
using System.IO;

using ChessMove = ChessDotNet.Move;

namespace PgnToFenCore
{
    public class SaveToFileStrategy : IConversionStrategy
    {
        public string Filename { get; }

        public SaveToFileStrategy(string filename) => Filename = filename;

        public void ConvertAllFens(Game game)
        {
            IEnumerable<ChessMove> moves = game.GetAllMoves();

            var newGame = new ChessGame();

            using var file = new StreamWriter(Filename, true);
            SaveAllFensToStream(moves, newGame, file);
        }

        private void SaveAllFensToStream(IEnumerable<ChessMove> moves, ChessGame game, StreamWriter stream)
        {
            stream.WriteLine(game.GetFen());

            foreach (var move in moves)
            {
                game.MakeMove(move, true);
                stream.WriteLine(game.GetFen());
            }
        }
    }
}
