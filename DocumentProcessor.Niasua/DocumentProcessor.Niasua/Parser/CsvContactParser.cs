using CsvHelper;
using DocumentProcessor.Niasua.Models;
using System.Globalization;

namespace DocumentProcessor.Niasua.Parser;

public class CsvContactParser : IFileParser<Contact>
{
    public List<Contact> Parse(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<Contact>();

        return new List<Contact>(records);
    }
}
