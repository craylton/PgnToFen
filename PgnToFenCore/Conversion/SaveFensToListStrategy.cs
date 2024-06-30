using ChessDotNet;
using ilf.pgn.Data;
using System.Collections.Generic;

using ChessMove = ChessDotNet.Move;

namespace PgnToFenCore.Conversion;

public class SaveFensToListStrategy : IConversionStrategy
{
    public ICollection<string> Fens { get; } = new List<string>();

    public void ConvertAllFens(Game game)
    {
        IEnumerable<ChessMove> moves = game.GetAllMoves();
        var newGame = new ChessGame();

        SaveAllFens(moves, newGame);
    }

    private void SaveAllFens(IEnumerable<ChessMove> moves, ChessGame game)
    {
        Fens.Add(game.GetFen());

        foreach (var move in moves)
        {
            game.MakeMove(move, true);
            Fens.Add(game.GetFen());
        }
    }
}
