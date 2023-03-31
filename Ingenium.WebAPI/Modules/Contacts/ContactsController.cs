using Ingenium.Modules.Contacts.Application.Contacts.CreateContact;
using Ingenium.Modules.Contacts.Application.Contacts.GetAllContacts;
using Ingenium.Modules.Contacts.Application.Contacts.GetContactById;
using Ingenium.Modules.Contacts.Application.Contacts.SearchContacts;
using Ingenium.Modules.Contacts.Application.Contacts.UpdateContactById;
using Ingenium.Modules.Contacts.Application.Contracts;
using Ingenium.WebAPI.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Ingenium.WebAPI.Modules.Contacts;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactsModule _contactsModule;

    public ContactsController(IContactsModule contactsModule)
    {
        _contactsModule = contactsModule;
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetContacts()
    {
        var contacts = await _contactsModule.ExecuteQueryAsync(new GetAllContactsQuery());

        return Ok(contacts.Select(ContactsMapper.MapContact).ToList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetContacts(long id)
    {
        var contact = await _contactsModule.ExecuteQueryAsync(new GetContactByIdQuery(id));

        if (contact == null)
        {
            return NotFound();
        }

        return Ok(ContactsMapper.MapContact(contact));
    }

    [HttpPost("Search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchContacts(SearchContactsRequest request)
    {
        var contacts = await _contactsModule.ExecuteQueryAsync(new SearchContactsQuery(
            request.NameQuery,
            request.TelQuery,
            request.FromQuery,
            request.ToQuery,
            request.IsActiveQuery
            ));

        return Ok(contacts.Select(ContactsMapper.MapContact).ToList());
    }

    [HttpPut("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateContact(CreateContactRequest request)
    {
        await _contactsModule.ExecuteCommandAsync(new CreateContactCommand(
            request.FirstName,
            request.LastName,
            request.IsActive,
            request.BirthDate,
            request.Email,
            request.TelephoneNumber
            ));

        return Ok();
    }

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateContact(UpdateContactRequest request)
    {
        var contactDto = ContactsMapper.MapContact(request.Contact);

        await _contactsModule.ExecuteCommandAsync(new UpdateContactByIdCommand(
            contactDto.Id,
            contactDto
            ));

        return Ok();
    }
}