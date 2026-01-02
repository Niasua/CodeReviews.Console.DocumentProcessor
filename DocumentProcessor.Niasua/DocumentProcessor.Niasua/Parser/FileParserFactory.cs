using DocumentProcessor.Niasua.Models;

namespace DocumentProcessor.Niasua.Parser;

public class FileParserFactory
{
    public static IFileParser<Contact> GetParser(string filePath)
    {
        // get extension
        var extension = Path.GetExtension(filePath).ToLower();

        // decide which parser to use
        return extension switch
        {
            ".csv" => new CsvContactParser(),
            ".xlsx" => new ExcelContactParser(),
            _ => throw new NotSupportedException($"Format {extension} is not supported!")
        };
    }
}
