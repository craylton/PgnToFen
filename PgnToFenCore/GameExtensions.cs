using ilf.pgn.Data;
using System.Collections.Generic;

using ChessMove = ChessDotNet.Move;

namespace PgnToFenCore
{
    internal static class GameExtensions
    {
        public static IEnumerable<ChessMove> GetAllMoves(this Game game) =>
            game.ToCleanPgn().GetMoves();

        private static CleanPgn ToCleanPgn(this Game game)
        {
            var rawPgn = game.ToString();

            var pgnWithoutHeaders = rawPgn.RemovePgnHeaders();
            return pgnWithoutHeaders[0..^4];
        }
    }
}
