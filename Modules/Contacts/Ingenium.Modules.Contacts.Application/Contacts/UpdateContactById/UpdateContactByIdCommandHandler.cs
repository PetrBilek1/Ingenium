using Ingenium.BuildingBlocks.Infrastructure.Exceptions;
using Ingenium.Modules.Contacts.Application.Configuration.Commands;
using Ingenium.Modules.Contacts.Domain.Repositories;

namespace Ingenium.Modules.Contacts.Application.Contacts.UpdateContactById;

internal sealed class UpdateContactByIdCommandHandler : ICommandHandler<UpdateContactByIdCommand>
{
    private readonly IContactsRepository _contactsRepository;

    public UpdateContactByIdCommandHandler(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public async Task Handle(UpdateContactByIdCommand command, CancellationToken cancellationToken)
    {
        var contact = await _contactsRepository.GetByIdAsync(command.Id, cancellationToken);
        if (contact == null)
        {
            throw new ResourceNotFoundException($"Contact not found by Id '{command.Id}'.");
        }

        contact.FirstName = command.Contact.FirstName;
        contact.LastName = command.Contact.LastName;
        contact.IsActive = command.Contact.IsActive;
        contact.BirthDate = command.Contact.BirthDate.Date;
        contact.Email = command.Contact.Email;
        contact.TelephoneNumber = command.Contact.TelephoneNumber.Replace(" ", "");
    }
}