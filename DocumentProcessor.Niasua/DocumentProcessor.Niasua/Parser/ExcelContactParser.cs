using ClosedXML.Excel;
using DocumentProcessor.Niasua.Models;

namespace DocumentProcessor.Niasua.Parser;

internal class ExcelContactParser : IFileParser<Contact>
{
    public List<Contact> Parse(string filePath)
    {
        using var workbook = new XLWorkbook(filePath);

        // use the first worksheet
        var worksheet = workbook.Worksheet(1);
        // for using only the active rows
        var rows = worksheet.RowsUsed();

        var contacts = new List<Contact>();
        
        foreach (var row in rows.Skip(1)) // the first is usually the header, so it's skipped
        { 
            var contact = new Contact
            {
                Name = row.Cell(1).GetValue<string>(),
                Email = row.Cell(2).GetValue<string>(),
                PhoneNumber = row.Cell(3).GetValue<string>()
            };

            contacts.Add(contact);
        }

        return contacts;
    }
}
