﻿using ChessDotNet;
using ilf.pgn.Data;
using System.Collections.Generic;

using ChessMove = ChessDotNet.Move;

namespace PgnToFen
{
    public class GameData
    {
        public int Result { get; }
        public IEnumerable<ChessMove> Moves { get; }

        private GameData(int result, IEnumerable<ChessMove> moves) => 
            (Result, Moves) = (result, moves);

        public static GameData FromGame(Game game)
        {
            var pgn = game.ToParseablePgn();
            var moves = GetMovesFromCleanedPgn(pgn);

            return new GameData(game.Result.GetWhiteScore(), moves);
        }

        private static IEnumerable<ChessMove> GetMovesFromCleanedPgn(string cleanedPgn)
        {
            var pgnTextReader = new PgnReader<ChessGame>();
            pgnTextReader.ReadPgnFromString(cleanedPgn);

            return pgnTextReader.Game.Moves;
        }
    }
}