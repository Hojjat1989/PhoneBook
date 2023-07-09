using System;

namespace PhoneBook.Domain.Repositories;

public interface IContactRepository
{
    Contact GetById(int id);
    IEnumerable<Contact> GetAllWithTagId(int tagId);

    void Add(Contact contact);
    void Update(UpdateContact contact);
    void Delete(int id);
}
