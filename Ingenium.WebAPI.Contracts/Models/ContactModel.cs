namespace Ingenium.WebAPI.Contracts.Models;

public sealed class ContactModel
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public string TelephoneNumber { get; set; } = string.Empty;
}