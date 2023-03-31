using Ingenium.Modules.Contacts.Application.Contracts;
using Ingenium.Modules.Contacts.Application.Contracts.Dto;

namespace Ingenium.Modules.Contacts.Application.Contacts.SearchContacts;

public sealed class SearchContactsQuery : IQuery<List<ContactDto>>
{
    public SearchContactsQuery(
        string? nameQuery,
        string? telQuery,
        DateTime? fromQuery,
        DateTime? toQuery,
        bool? isActiveQuery)
    {
        NameQuery = nameQuery;
        TelQuery = telQuery;
        FromQuery = fromQuery;
        ToQuery = toQuery;
        IsActiveQuery = isActiveQuery;
    }

    public string? NameQuery { get; }
    public string? TelQuery { get; }
    public DateTime? FromQuery { get; }
    public DateTime? ToQuery { get; }
    public bool? IsActiveQuery { get; }
}