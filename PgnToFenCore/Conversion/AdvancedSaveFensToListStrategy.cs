using System.Collections.Generic;
using ChessDotNet;
using ilf.pgn.Data;

using ChessMove = ChessDotNet.Move;

namespace PgnToFenCore.Conversion
{
    public class AdvancedSaveFensToListStrategy : IConversionStrategy
    {
        public ICollection<FenData> Positions { get; } = new List<FenData>();

        public void ConvertAllFens(Game game)
        {
            IEnumerable<ChessMove> moves = game.GetAllMoves();
            var newGame = new ChessGame();
            FinalGameResult result = game.Result.GetFinalResult();

            SaveAllFens(moves, newGame, result);
        }

        private void SaveAllFens(IEnumerable<ChessMove> moves, ChessGame game, FinalGameResult result)
        {
            Positions.Add(FenData.FromGameState(game, result));

            foreach (var move in moves)
            {
                game.MakeMove(move, true);
                var fenData = FenData.FromGameState(game, result);
                Positions.Add(fenData);
            }
        }
    }
}
