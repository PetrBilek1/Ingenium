using Ingenium.Modules.Contacts.Application.Contracts.Dto;
using Ingenium.Modules.Contacts.Domain.Entities;

namespace Ingenium.Modules.Contacts.Application.Configuration.Mapping;

internal static class ContactsMapper
{
    public static ContactDto MapContact(Contact entity)
        => new ContactDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            IsActive = entity.IsActive,
            BirthDate = entity.BirthDate,
            Email = entity.Email,
            TelephoneNumber = entity.TelephoneNumber,
        };
}