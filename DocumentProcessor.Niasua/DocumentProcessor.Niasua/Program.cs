using DocumentProcessor.Niasua.Data;
using DocumentProcessor.Niasua.Parser;

var filePath = "contacts.csv";

try
{
    Console.WriteLine($"Reading file: {filePath}...");
    var parser = FileParserFactory.GetParser(filePath);
    var contacts = parser.Parse(filePath);
    Console.WriteLine($"-> {contacts.Count} contacts found!");

    Console.WriteLine("Connecting to database...");
    using (var dbContext = new PhoneBookContext())
    {
        var seeder = new DataSeeder(dbContext);
        seeder.Seed(contacts);
    }

    Console.WriteLine("-> Process finished successfully!");
}
catch (Exception ex)
{
    Console.WriteLine($"Critical error! {ex.Message}");
}