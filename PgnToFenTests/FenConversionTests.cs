using PgnToFenCore;
using PgnToFenCore.Conversion;

namespace PgnToFenTests;

[TestClass]
public class FenConversionTests
{
    private readonly SaveFensToListStrategy conversionStrategy = new();

    [TestMethod]
    public void LichessOpenGame()
    {
        PgnToFenConverter.Convert(conversionStrategy, "Data/lichess-open-game-input.pgn");

        IEnumerable<string> expected = File.ReadAllLines("Data/lichess-open-game-output.txt");
        IEnumerable<string> actual = conversionStrategy.Fens;

        Assert.IsTrue(actual.SequenceEqual(expected));
    }

    [TestMethod]
    public void MultipleGames()
    {
        PgnToFenConverter.Convert(conversionStrategy, "Data/multiple-games-input.pgn");

        IEnumerable<string> expected = File.ReadAllLines("Data/multiple-games-output.txt");
        IEnumerable<string> actual = conversionStrategy.Fens;

        Assert.IsTrue(actual.SequenceEqual(expected));
    }

    [TestMethod]
    public void TcecTournament()
    {
        PgnToFenConverter.Convert(conversionStrategy, "Data/tcec-tournament-input.pgn");

        IEnumerable<string> expected = File.ReadAllLines("Data/tcec-tournament-output.txt");
        IEnumerable<string> actual = conversionStrategy.Fens;

        Assert.IsTrue(actual.SequenceEqual(expected));
    }
}