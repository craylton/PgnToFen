using ilf.pgn.Data;
using System.Linq;

namespace PgnToFen
{
    public static class GameExtensions
    {
        public static string ToParseablePgn(this Game game)
        {
            var rawPgn = game.ToString();

            var pgnWithoutHeaders = rawPgn.RemoveLinesWhere(line => line.Contains('['));
            return pgnWithoutHeaders.Substring(0, pgnWithoutHeaders.Length - 4);
        }
    }
}
