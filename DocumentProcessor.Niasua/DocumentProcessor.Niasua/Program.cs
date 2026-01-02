using DocumentProcessor.Niasua.Data;
using DocumentProcessor.Niasua.Parser;
using DocumentProcessor.Niasua.Reports;
using QuestPDF.Infrastructure;

// free to use license
QuestPDF.Settings.License = LicenseType.Community;

var filePath = "contacts.csv";

try
{
    Console.WriteLine($"Reading file: {filePath}...");
    // use the factory to get the concrete parser
    var parser = FileParserFactory.GetParser(filePath);
    var contacts = parser.Parse(filePath);
    Console.WriteLine($"-> {contacts.Count} contacts found!");

    Console.WriteLine("Connecting to database...");
    using (var dbContext = new PhoneBookContext())
    {
        var seeder = new DataSeeder(dbContext);
        seeder.Seed(contacts);
    }


    Console.WriteLine("Generating PDF report...");

    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string fullPath = Path.Combine(desktop, "Final_Report.pdf");

    Console.WriteLine($"Saving file in: {fullPath}");

    var pdfGenerator = new PdfReportGenerator();
    pdfGenerator.Generate(contacts, fullPath);

    Console.WriteLine("-> Process finished successfully!");
}
catch (Exception ex)
{
    Console.WriteLine($"Critical error! {ex.Message}");
}