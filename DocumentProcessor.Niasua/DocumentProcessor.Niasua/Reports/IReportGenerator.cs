using DocumentProcessor.Niasua.Models;

namespace DocumentProcessor.Niasua.Reports;

public interface IReportGenerator
{
    public void Generate(List<Contact> contacts, string filePath);
}
