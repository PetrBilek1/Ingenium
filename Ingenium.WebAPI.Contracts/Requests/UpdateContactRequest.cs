using Ingenium.WebAPI.Contracts.Models;
using System.ComponentModel.DataAnnotations;

namespace Ingenium.WebAPI.Contracts.Requests;

public sealed class UpdateContactRequest
{
    [Required]
    public ContactModel Contact { get; set; }
}