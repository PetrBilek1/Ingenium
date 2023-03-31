using Ingenium.Modules.Contacts.Application.Contracts;
using Ingenium.Modules.Contacts.Application.Contracts.Dto;

namespace Ingenium.Modules.Contacts.Application.Contacts.GetContactById;

public sealed class GetContactByIdQuery : IQuery<ContactDto?>
{
    public GetContactByIdQuery(long id)
    {
        Id = id;
    }

    public long Id { get; }
}