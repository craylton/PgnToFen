using ilf.pgn.Data;

namespace PgnToFenCore
{
    internal static class GameExtensions
    {
        public static string ToParseablePgn(this Game game)
        {
            var rawPgn = game.ToString();

            var pgnWithoutHeaders = rawPgn.RemoveLinesWhere(line => line.Contains('['));
            return pgnWithoutHeaders[0..^4];
        }
    }
}
