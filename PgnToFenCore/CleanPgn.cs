using ChessDotNet;
using System.Collections.Generic;

using ChessMove = ChessDotNet.Move;

namespace PgnToFenCore;

internal class CleanPgn(string value)
{
    public string Value { get; } = value;

    public static implicit operator CleanPgn(string str) => new(str);

    public IEnumerable<ChessMove> GetMoves()
    {
        var pgnTextReader = new PgnReader<ChessGame>();
        pgnTextReader.ReadPgnFromString(Value);

        return pgnTextReader.Game.Moves;
    }
}
