using ilf.pgn.Data;

namespace PgnToFenCore;

internal static class GameResultExtensions
{
    public static FinalGameResult GetFinalResult(this GameResult gameResult) => gameResult switch
    {
        GameResult.White => FinalGameResult.WhiteWin,
        GameResult.Black => FinalGameResult.BlackWin,
        _ => FinalGameResult.Draw,
    };
}
