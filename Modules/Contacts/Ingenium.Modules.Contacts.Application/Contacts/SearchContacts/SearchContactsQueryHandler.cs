using Ingenium.Modules.Contacts.Application.Configuration.Commands;
using Ingenium.Modules.Contacts.Application.Configuration.Mapping;
using Ingenium.Modules.Contacts.Application.Contracts.Dto;
using Ingenium.Modules.Contacts.Domain.Repositories;

namespace Ingenium.Modules.Contacts.Application.Contacts.SearchContacts;

internal class SearchContactsQueryHandler : IQueryHandler<SearchContactsQuery, List<ContactDto>>
{
    private readonly IContactsRepository _contactsRepository;

    public SearchContactsQueryHandler(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public async Task<List<ContactDto>> Handle(SearchContactsQuery query, CancellationToken cancellationToken)
    {
        var contacts = await _contactsRepository.SearchAsync(
            query.NameQuery,
            query.TelQuery?.Replace(" ", ""),
            query.FromQuery,
            query.ToQuery,
            query.IsActiveQuery,
            cancellationToken);

        return contacts.Select(ContactsMapper.MapContact).ToList();
    }
}