using System;

namespace PhoneBook.Api.Models;

public class ContactModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public string[] Tags { get; set; }
}
