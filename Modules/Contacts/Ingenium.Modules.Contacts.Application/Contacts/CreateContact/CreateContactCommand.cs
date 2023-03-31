using Ingenium.Modules.Contacts.Application.Contracts;

namespace Ingenium.Modules.Contacts.Application.Contacts.CreateContact;

public sealed class CreateContactCommand : ICommand
{
    public CreateContactCommand(
        string firstName,
        string lastName,
        bool isActive,
        DateTime birthDate,
        string email,
        string telephoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        IsActive = isActive;
        BirthDate = birthDate;
        Email = email;
        TelephoneNumber = telephoneNumber;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public bool IsActive { get; }
    public DateTime BirthDate { get; }
    public string Email { get; }
    public string TelephoneNumber { get; }
}