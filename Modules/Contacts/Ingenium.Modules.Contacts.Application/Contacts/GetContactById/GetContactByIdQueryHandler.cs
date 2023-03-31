using Ingenium.Modules.Contacts.Application.Configuration.Commands;
using Ingenium.Modules.Contacts.Application.Configuration.Mapping;
using Ingenium.Modules.Contacts.Application.Contracts.Dto;
using Ingenium.Modules.Contacts.Domain.Repositories;

namespace Ingenium.Modules.Contacts.Application.Contacts.GetContactById;

public sealed class GetContactByIdQueryHandler : IQueryHandler<GetContactByIdQuery, ContactDto?>
{
    private readonly IContactsRepository _contactsRepository;

    public GetContactByIdQueryHandler(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public async Task<ContactDto?> Handle(GetContactByIdQuery query, CancellationToken cancellationToken)
    {
        var contact = await _contactsRepository.GetByIdAsync(query.Id, cancellationToken);

        return contact == null 
            ? null
            : ContactsMapper.MapContact(contact);
    }
}