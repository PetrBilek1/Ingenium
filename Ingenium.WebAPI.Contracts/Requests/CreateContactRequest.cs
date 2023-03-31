using System.ComponentModel.DataAnnotations;

namespace Ingenium.WebAPI.Contracts.Requests;

public sealed class CreateContactRequest
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public bool IsActive { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string TelephoneNumber { get; set; }
}