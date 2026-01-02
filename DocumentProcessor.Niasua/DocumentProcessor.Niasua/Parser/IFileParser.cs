namespace DocumentProcessor.Niasua.Parser;

internal interface IFileParser<T>
{
    List<T> Parse(string filePath);
}
