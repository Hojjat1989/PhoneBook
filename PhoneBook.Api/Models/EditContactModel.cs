﻿using System;

namespace PhoneBook.Api.Models;

public class EditContactModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}
