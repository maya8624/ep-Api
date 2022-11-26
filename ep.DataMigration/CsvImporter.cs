using CsvHelper;
using System.Globalization;

namespace ep.DataMigration
{
    public class CsvImporter
    {
        public static List<T> ReadCsvFile<T>(string file)
        {
            using var streamReader = new StreamReader(@"../../../Import/" + file);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            return csvReader.GetRecords<T>().ToList();
        }
    }
}
