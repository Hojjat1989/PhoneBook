using System;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Utilities;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;

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

    [HttpPost]
    [Route("")]
    public IActionResult Add([FromBody] CreateContact contact)
    {
        _contactService.CreateContact(contact);
        return Ok();
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

    [HttpPost]
    [Route("update")]
    public IActionResult Update([FromBody] UpdateContact model)
    {
        var contact = _contactService.GetContactById(model.Id);
        if (contact == null)
        {
            return NotFound();
        }

        _contactService.UpdateContact(model);
        return Ok();
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
