using System;
using PhoneBook.Domain;
using PhoneBook.Domain.Repositories;

namespace PhoneBook.Infrastructure;

public class MemContactRepository : IContactRepository
{
    private readonly List<Contact> _contacts;
    private readonly List<Tag> _tags;

    public MemContactRepository()
    {
        _contacts = new List<Contact>();
        _tags = new List<Tag>();
    }

    public Contact GetById(int id)
    {
        return _contacts.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Contact> GetAllWithTagId(int tagId)
    {
        var result = _contacts.Where(x => x.Tags.Any(t => t.Id == tagId));
        return result.ToList();
    }

    public void Add(CreateContact contact)
    {
        var dbContact = new Contact
        {
            Id = _contacts.Count + 1,
            Name = contact.Name,
            PhoneNumber = contact.PhoneNumber,
            Tags = new List<ContactTag>()
        };
        AddTags(dbContact, contact.Tags);

        _contacts.Add(dbContact);
    }

    public void Update(UpdateContact contact)
    {
        var existingContact = GetById(contact.Id);
        if (existingContact != null)
        {
            existingContact.Name = contact.Name;
            existingContact.PhoneNumber = contact.PhoneNumber;
        }
    }

    public void Delete(int id)
    {
        var contact = GetById(id);
        if (contact != null)
        {
            _contacts.Remove(contact);
        }
    }

    private void AddTags(Contact contact, Tag[] tags)
    {
        foreach (var item in tags)
        {
            Tag tag = null;
            if (item.Id >= 0)
            {
                tag = _tags.FirstOrDefault(x => x.Id == item.Id);
            }
            else
            {
                tag = new Tag
                {
                    Id = _tags.Count + 1,
                    Title = item.Title
                };
                _tags.Add(tag);
            }

            contact.Tags.Add(new ContactTag
            {
                Tag = tag,
                TagId = tag.Id,
                Contact = contact,
                ContactId = contact.Id
            });
        }
    }
}