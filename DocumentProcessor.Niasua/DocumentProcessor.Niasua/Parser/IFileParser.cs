namespace DocumentProcessor.Niasua.Parser;

public interface IFileParser<T>
{
    List<T> Parse(string filePath);
}
