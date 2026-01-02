using CsvHelper.Configuration.Attributes;

namespace DocumentProcessor.Niasua.Models;

internal class Contact
{
    [Ignore]
    public int Id { get; set; }

    [Name("First Name")]
    public string Name { get; set; }

    [Name("Email Address")]
    public string Email { get; set; }

    [Name("Phone")]
    public string PhoneNumber { get; set; }
}
