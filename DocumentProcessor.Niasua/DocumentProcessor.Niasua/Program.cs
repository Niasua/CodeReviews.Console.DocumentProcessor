using DocumentProcessor.Niasua.Parser;

var filePath = "contacts.csv";

var parser = FileParserFactory.GetParser(filePath);

var contacts = parser.Parse(filePath);

Console.WriteLine($"{contacts.Count} were found");

foreach (var contact in contacts)
{
    Console.WriteLine(contact.Name);
}