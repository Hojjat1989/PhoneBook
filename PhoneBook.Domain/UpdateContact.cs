﻿using System;

namespace PhoneBook.Domain;

public class UpdateContact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}
