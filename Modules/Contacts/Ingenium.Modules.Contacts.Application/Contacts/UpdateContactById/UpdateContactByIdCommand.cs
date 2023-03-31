using Ingenium.Modules.Contacts.Application.Contracts;
using Ingenium.Modules.Contacts.Application.Contracts.Dto;

namespace Ingenium.Modules.Contacts.Application.Contacts.UpdateContactById;

public sealed class UpdateContactByIdCommand : ICommand
{
    public UpdateContactByIdCommand(long id, ContactDto contact) 
    { 
        Id = id;
        Contact = contact;
    }

    public long Id { get; }
    public ContactDto Contact { get; }
}