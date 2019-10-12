using ChessDotNet;

namespace PgnToFenCore
{
    public class FenData
    {
        public string Fen { get; }

        public int MoveNumber { get; }

        public FinalGameResult FinalResult { get; }

        public FenData(string fen, int moveNumber, FinalGameResult finalResult) => 
            (Fen, MoveNumber, FinalResult) = (fen, moveNumber, finalResult);

        public static FenData FromGameState(ChessGame game, FinalGameResult endResult)
        {
            var fen = game.GetFen();
            var moveNumber = game.FullMoveNumber;

            return new FenData(fen, moveNumber, endResult);
        }
    }
}