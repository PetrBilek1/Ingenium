using Ingenium.Modules.Contacts.Domain.Entities;

namespace Ingenium.Modules.Contacts.Domain.Repositories;

public interface IContactsRepository
{
    Task AddAsync(Contact contact);
    Task<Contact?> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<List<Contact>> ListAsync(CancellationToken cancellationToken);
    Task<List<Contact>> SearchAsync(
        string? nameQuery,
        string? telQuery,
        DateTime? fromQuery,
        DateTime? toQuery,
        bool? isActiveQuery,
        CancellationToken cancellationToken);
}