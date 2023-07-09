using System;
using PhoneBook.Domain.Base;

namespace PhoneBook.Domain;

public class ContactTag : EntityBase
{
    public int ContactId { get; set; }
    public int TagId { get; set; }

    public Contact Contact { get; set; }
    public Tag Tag { get; set; }
}
