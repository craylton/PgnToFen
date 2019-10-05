using ChessDotNet;
using System.Collections.Generic;

using ChessMove = ChessDotNet.Move;

namespace PgnToFenCore
{
    internal class CleanPgn
    {
        public string Value { get; }

        public CleanPgn(string value) => Value = value;

        public static implicit operator CleanPgn(string str) => new CleanPgn(str);

        public IEnumerable<ChessMove> GetMoves()
        {
            var pgnTextReader = new PgnReader<ChessGame>();
            pgnTextReader.ReadPgnFromString(Value);

            return pgnTextReader.Game.Moves;
        }
    }
}
