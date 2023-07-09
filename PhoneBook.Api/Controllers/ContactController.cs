using System;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Utilities;
using PhoneBook.Application.Interfaces;

namespace PhoneBook.Api.Controllers;

[ApiController]
[Route("v1/contacts")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        var contact = _contactService.GetContactById(id);
        if (contact == null)
        {
            return NotFound();
        }

        var result = contact.ToContactModel();
        return Ok(result);
    }

    [HttpGet]
    [Route("bytag/{tagId}")]
    public IActionResult GetContactsByTagId(int tagId)
    {
        var contact = _contactService.GetContactsWithTagId(tagId);

        var result = contact.Select(x => x.ToContactModel()).ToList();
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteContact(int id)
    {
        var contact = _contactService.GetContactById(id);
        if (contact == null)
        {
            return NotFound();
        }

        _contactService.DeleteContact(id);
        return Ok();
    }
}
