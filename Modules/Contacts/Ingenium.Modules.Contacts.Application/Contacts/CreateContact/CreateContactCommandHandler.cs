using Ingenium.Modules.Contacts.Application.Configuration.Commands;
using Ingenium.Modules.Contacts.Domain.Entities;
using Ingenium.Modules.Contacts.Domain.Repositories;

namespace Ingenium.Modules.Contacts.Application.Contacts.CreateContact;

internal sealed class CreateContactCommandHandler : ICommandHandler<CreateContactCommand>
{
    private readonly IContactsRepository _contactsRepository;

    public CreateContactCommandHandler(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public async Task Handle(CreateContactCommand command, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            IsActive = command.IsActive,
            BirthDate = command.BirthDate.Date,
            Email = command.Email,
            TelephoneNumber = command.TelephoneNumber.Replace(" ", ""),
        };

        await _contactsRepository.AddAsync(contact);
    }
}