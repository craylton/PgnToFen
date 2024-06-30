using ilf.pgn.Data;

namespace PgnToFenCore.Conversion;

public interface IConversionStrategy
{
    void ConvertAllFens(Game game);
}
