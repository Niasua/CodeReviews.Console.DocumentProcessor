using DocumentProcessor.Niasua.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace DocumentProcessor.Niasua.Reports;

public class PdfReportGenerator : IReportGenerator
{
    public void Generate(List<Contact> contacts, string filePath)
    {
        Document.Create(container =>
        {
            container.Page(page =>
            {
                // basic page config
                page.Margin(50);

                // header
                page.Header().Text("Contacts Report")
                    .SemiBold().FontSize(30).FontColor(Colors.Blue.Medium);

                // content
                page.Content().PaddingVertical(10).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    // defining columns
                    table.Header(header =>
                    {
                        header.Cell().Text("Name");
                        header.Cell().Text("Email");
                        header.Cell().Text("Tel");
                    });

                    foreach (var contact in contacts)
                    {
                        table.Cell().Text(contact.Name);
                        table.Cell().Text(contact.Email);
                        table.Cell().Text(contact.PhoneNumber);
                    }

                });

                // footer
                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                });
            });
        })
        .GeneratePdf(filePath);
    }
}
