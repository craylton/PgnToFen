using ilf.pgn.Data;

namespace PgnToFenCore
{
    public interface IConversionStrategy
    {
        void ConvertAllFens(Game game);
    }
}
