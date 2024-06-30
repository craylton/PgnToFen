# PgnToFen
A utility for transforming a PGN file of chess games into a list of all the positions in those games. The application is written in C# in .NET Core.

The project makes heavy use of a couple of other projects:

- [ilf.pgn.net](https://github.com/teodoran/pgn.net) - for parsing PGN files into chess game data. That project is a .NET Core port of [this project](https://github.com/iigorr/pgn.net).

- [Chess.NET](https://github.com/thomas-daniels/Chess.NET) - for converting positions into FENs.

## Simple Example
Input:
```
[White "P1"]
[Black "P2"]
[Result "1-0"]

1. e4 e5 2. Bc4 Nc6 3. Qh5 Nf6 4. Qxf7# 1-0
```
Output:
```
rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1
rnbqkbnr/pppp1ppp/8/4p3/4P3/8/PPPP1PPP/RNBQKBNR w KQkq e6 0 2
rnbqkbnr/pppp1ppp/8/4p3/2B1P3/8/PPPP1PPP/RNBQK1NR b KQkq - 1 2
r1bqkbnr/pppp1ppp/2n5/4p3/2B1P3/8/PPPP1PPP/RNBQK1NR w KQkq - 2 3
r1bqkbnr/pppp1ppp/2n5/4p2Q/2B1P3/8/PPPP1PPP/RNB1K1NR b KQkq - 3 3
r1bqkb1r/pppp1ppp/2n2n2/4p2Q/2B1P3/8/PPPP1PPP/RNB1K1NR w KQkq - 4 4
r1bqkb1r/pppp1Qpp/2n2n2/4p3/2B1P3/8/PPPP1PPP/RNB1K1NR b KQkq - 0 4
```

## How to use

You can run the application from the command line with the name of the file to convert. For example:

```shell
PgnToFen.exe --pgnfile MyPgnFile.pgn
```

This will create a file called MyPgnFile.txt containing a list of all of the FENs, in the same directory as the PGN file.

You can optionally specify the location to output the FENs to with the `--output` flag:

```shell
PgnToFen.exe --pgnfile MyPgnFile.pgn --output MyFenFile.txt
```

You can also use it as part of your own project. Once you've imported PgnToFen into your solution, you can use the snippet below to save FENs to a specific location:

```csharp
var conversionStrategy = new SaveFensToFileStrategy("MyFenFile.txt");
PgnToFenConverter.Convert(conversionStrategy, "MyPgnFile.pgn");
```

There are a couple of other 'strategies' you can use to do different things with the FENs. For example, this snippet will put all FENs into a `List<string>`:

```csharp
var conversionStrategy = new SaveFensToListStrategy();
PgnToFenConverter.Convert(conversionStrategy, "MyPgnFile.pgn");

foreach (var fen in conversionStrategy.Fens)
    Console.WriteLine(fen);
```

There is also an `AdvancedSaveFensToListStrategy`, which is similar to the above, but instead of storing just the FEN, it will also store some metadata, such as who won the game in the end.

```csharp
var conversionStrategy = new AdvancedSaveFensToListStrategy();
PgnToFenConverter.Convert(conversionStrategy, "MyPgnFile.pgn");

var decisivePositions = conversionStrategy.Positions
    .Where(position => position.FinalResult != FinalGameResult.Draw);
    
foreach (var position in decisivePositions)
    Console.WriteLine(position.Fen);
```
