using System;
using PhoneBook.Domain;
using PhoneBook.Domain.Repositories;

namespace PhoneBook.Infrastructure
{
    public class MemContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts;

        public MemContactRepository()
        {
            _contacts = new List<Contact>();
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

        public void Add(Contact contact)
        {
            contact.Id = _contacts.Count + 1;
            _contacts.Add(contact);
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
    }
}