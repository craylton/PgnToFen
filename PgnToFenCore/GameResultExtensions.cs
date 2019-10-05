using ilf.pgn.Data;

namespace PgnToFen
{
    public static class GameResultExtensions
    {
        public static int GetWhiteScore(this GameResult gameResult) =>
            ((int)gameResult - 1).Modulo(3);
    }
}
