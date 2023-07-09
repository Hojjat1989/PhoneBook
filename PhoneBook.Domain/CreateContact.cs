using System;

namespace PhoneBook.Domain;

public class CreateContact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Tag[] Tags { get; set; }
}
