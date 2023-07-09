using System;
using PhoneBook.Domain;

namespace PhoneBook.Application.Interfaces;

public interface IContactService
{
    Contact GetContactById(int id);
    IEnumerable<Contact> GetContactsWithTagId(int tagId);
    void CreateContact(Contact contact);
    void UpdateContact(UpdateContact contact);
    void DeleteContact(int id);
}
