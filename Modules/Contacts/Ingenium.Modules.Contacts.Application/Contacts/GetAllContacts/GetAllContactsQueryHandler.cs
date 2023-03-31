using Ingenium.Modules.Contacts.Application.Configuration.Commands;
using Ingenium.Modules.Contacts.Application.Configuration.Mapping;
using Ingenium.Modules.Contacts.Application.Contracts.Dto;
using Ingenium.Modules.Contacts.Domain.Repositories;

namespace Ingenium.Modules.Contacts.Application.Contacts.GetAllContacts;

internal sealed class GetAllContactsQueryHandler : IQueryHandler<GetAllContactsQuery, List<ContactDto>>
{
    private readonly IContactsRepository _contactsRepository;

    public GetAllContactsQueryHandler(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public async Task<List<ContactDto>> Handle(GetAllContactsQuery query, CancellationToken cancellationToken)
    {
        var contacts = await _contactsRepository.ListAsync(cancellationToken);

        return contacts.Select(ContactsMapper.MapContact).ToList();
    }
}