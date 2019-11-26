using ChessDotNet;

namespace PgnToFenCore
{
    public class FenData
    {
        /// <summary>The FEN format describing the position.</summary>
        public string Fen { get; }

        /// <summary>The full move number (a move is when both players make a move).</summary>
        public int MoveNumber { get; }

        /// <summary>The final outcome of this game - white wins, black wins, or draw.</summary>
        public FinalGameResult FinalResult { get; }

        /// <summary>Whether white is the side to move in the current position.</summary>
        public bool IsWhiteToMove { get; }

        /// <summary>Whether the game has ended in this position, either in checkmate or stalemate.</summary>
        public bool IsTerminated { get; }

        /// <summary>The total value of the material on the board,
        /// where Pawn=1, Knight=3, Bishop=3, Rook=5 and Queen=9.</summary>
        public int TotalMaterialOnBoard { get; }

        public FenData(
            string fen,
            int moveNumber,
            FinalGameResult finalResult,
            bool isWhiteToMove,
            bool isTerminated,
            int totalMaterialOnBoard) =>
            (Fen, MoveNumber, FinalResult, IsWhiteToMove, IsTerminated, TotalMaterialOnBoard) =
            (fen, moveNumber, finalResult, isWhiteToMove, isTerminated, totalMaterialOnBoard);

        public static FenData FromGameState(ChessGame game, FinalGameResult endResult) =>
            new FenData(
                game.GetFen(),
                game.FullMoveNumber,
                endResult,
                game.WhoseTurn == Player.White,
                game.IsTerminated(),
                game.GetAmountOfMaterialOnBoard());
    }
}