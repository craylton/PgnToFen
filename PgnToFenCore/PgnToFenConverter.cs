using ilf.pgn;
using ilf.pgn.Data;
using PgnToFenCore.Conversion;

namespace PgnToFenCore
{
    public class PgnToFenConverter
    {
        public void Convert(IConversionStrategy strategy, string pgnFilename)
        {
            var pgnFileReader = new PgnReader();
            Database gameDb = pgnFileReader.ReadFromFile(pgnFilename);

            foreach (var game in gameDb.Games)
            {
                strategy.ConvertAllFens(game);
            }
        }
    }
}
