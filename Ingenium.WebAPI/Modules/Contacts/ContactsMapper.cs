using Ingenium.Modules.Contacts.Application.Contracts.Dto;
using Ingenium.WebAPI.Contracts.Models;

namespace Ingenium.WebAPI.Modules.Contacts;

internal static class ContactsMapper
{
    public static ContactModel MapContact(ContactDto dto)
        => new ContactModel
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            IsActive = dto.IsActive,
            BirthDate = dto.BirthDate,
            Email = dto.Email,
            TelephoneNumber = dto.TelephoneNumber,
        };

    public static ContactDto MapContact(ContactModel model)
        => new ContactDto
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            IsActive = model.IsActive,
            BirthDate = model.BirthDate,
            Email = model.Email,
            TelephoneNumber = model.TelephoneNumber,
        };
}