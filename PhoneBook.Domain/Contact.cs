using System;
using PhoneBook.Domain.Base;

namespace PhoneBook.Domain;

public class Contact : EntityBase
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public virtual ICollection<ContactTag> Tags { get; set; }
}
