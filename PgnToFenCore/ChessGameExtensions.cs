using ChessDotNet;
using System.Linq;

namespace PgnToFenCore;

internal static class ChessGameExtensions
{
    public static bool IsTerminated(this ChessGame game) =>
        game.IsDraw() || game.IsCheckmated(Player.White) || game.IsCheckmated(Player.Black);

    public static int GetAmountOfMaterialOnBoard(this ChessGame game) =>
        game.PiecesOnBoard.Aggregate(0, (sum, piece) => sum + piece.GetPieceValue());
}
