using ChessDotNet;

namespace PgnToFenCore
{
    public class FenData
    {
        public string Fen { get; }
        public int MoveNumber { get; }
        public FinalGameResult FinalResult { get; }
        public bool IsWhiteToMove { get; }

        public FenData(string fen, int moveNumber, FinalGameResult finalResult, bool isWhiteToMove) =>
            (Fen, MoveNumber, FinalResult, IsWhiteToMove) = (fen, moveNumber, finalResult, isWhiteToMove);

        public static FenData FromGameState(ChessGame game, FinalGameResult endResult)
        {
            var fen = game.GetFen();
            var moveNumber = game.FullMoveNumber;
            var isWhiteToMove = game.WhoseTurn == Player.White;

            return new FenData(fen, moveNumber, endResult, isWhiteToMove);
        }
    }
}