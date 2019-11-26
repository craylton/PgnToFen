using ChessDotNet;

namespace PgnToFenCore
{
    public class FenData
    {
        public string Fen { get; }
        public int MoveNumber { get; }
        public FinalGameResult FinalResult { get; }
        public bool IsWhiteToMove { get; }
        public bool IsTerminated { get; }
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