using ilf.pgn.Data;
using System.Collections.Generic;

namespace PgnToFen
{
    public class GameData
    {
        public int Result { get; }
        public IEnumerable<ChessDotNet.Move> Moves { get; }

        private GameData(int result, IEnumerable<ChessDotNet.Move> moves) => 
            (Result, Moves) = (result, moves);

        public static GameData FromGame(Game game)
        {
            var pgn = game.ToParseablePgn();
            var moves = GetMovesFromCleanedPgn(pgn);

            return new GameData(game.Result.GetWhiteScore(), moves);
        }

        private static IEnumerable<ChessDotNet.Move> GetMovesFromCleanedPgn(string cleanedPgn)
        {
            var pgnTextReader = new ChessDotNet.PgnReader<ChessDotNet.ChessGame>();
            pgnTextReader.ReadPgnFromString(cleanedPgn);

            return pgnTextReader.Game.Moves;
        }
    }
}
