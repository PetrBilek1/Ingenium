using Ingenium.WebAPI.Contracts.Models;

namespace Ingenium.WebUI.Services.Contracts;

public interface IContactService
{
    Task<ContactModel> GetByIdAsync(long id);
    Task<List<ContactModel>> GetAllAsync();
    Task<List<ContactModel>> SearchAsync(
        string? nameQuery,
        string? telQuery,
        DateTime? fromQuery,
        DateTime? toQuery,
        bool? isActiveQuery);
    Task CreateContactAsync(ContactModel contact);
    Task UpdateContactAsync(ContactModel contact);
}