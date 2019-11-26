using ChessDotNet;
using ChessDotNet.Pieces;

namespace PgnToFenCore
{
    internal static class PieceExtensions
    {
        public static int GetPieceValue(this Piece piece) =>
            piece switch
            {
                Pawn _ => 1,
                Knight _ => 3,
                Bishop _ => 3,
                Rook _ => 5,
                Queen _ => 9,
                _ => 0,
            };
    }
}
