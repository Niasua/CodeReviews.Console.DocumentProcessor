using DocumentProcessor.Niasua.Models;
using DocumentProcessor.Niasua.Parser;

namespace DocumentProcessor.Niasua.Data;

public class DataSeeder
{
    private readonly PhoneBookContext _context;
    public DataSeeder(PhoneBookContext context)
    {
        _context = context;
    }

    public void Seed(List<Contact> contactsFromFile)
    {
        var emails = _context.Contacts.Select(c => c.Email).ToList();

        var filteredContacts = contactsFromFile.Where(c => !emails.Contains(c.Email.ToLower())).ToList();

        _context.Contacts.AddRange(filteredContacts);
        _context.SaveChanges();
    }
}
