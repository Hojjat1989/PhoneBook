using PhoneBook.Api.Models;
using PhoneBook.Domain;

namespace PhoneBook.Api.Utilities;

public static class ContactExtensions
{
    public static ContactModel ToContactModel(this Contact contact)
    {
        return new ContactModel
        {
            Id = contact.Id,
            Name = contact.Name,
            PhoneNumber = contact.PhoneNumber,
            Tags = contact.Tags.Select(x => x.Tag.Title).ToArray(),
        };
    }
}
