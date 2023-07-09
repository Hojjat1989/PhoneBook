using System;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain.Repositories;
using PhoneBook.Domain;

namespace PhoneBook.Application.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public Contact GetContactById(int id)
    {
        return _contactRepository.GetById(id);
    }

    public IEnumerable<Contact> GetContactsWithTagId(int tagId)
    {
        return _contactRepository.GetAllWithTagId(tagId);
    }

    public void CreateContact(Contact contact)
    {
        _contactRepository.Add(contact);
    }

    public void UpdateContact(Contact contact)
    {
        _contactRepository.Update(contact);
    }

    public void DeleteContact(int id)
    {
        _contactRepository.Delete(id);
    }
}
