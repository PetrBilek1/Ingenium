using Ingenium.BuildingBlocks.Infrastructure;
using Ingenium.Modules.Contacts.Domain.Entities;
using Ingenium.Modules.Contacts.Domain.Repositories;
using Ingenium.Modules.Contacts.ORM;
using Microsoft.EntityFrameworkCore;

namespace Ingenium.Modules.Contacts.Infrastructure.Domain.Contacts;

public sealed class ContactsRepository : RepositoryBase<ContactsContext>, IContactsRepository
{
    public ContactsRepository(IUnitOfWorkProvider provider) : base(provider)
    {
    }

    public async Task AddAsync(Contact contact)
    {
        await DbContext.Contacts.AddAsync(contact);
    }

    public async Task<Contact?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await DbContext.Contacts
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<Contact>> ListAsync(CancellationToken cancellationToken)
    {
        return await DbContext.Contacts.ToListAsync(cancellationToken);
    }

    public async Task<List<Contact>> SearchAsync(
        string? nameQuery,
        string? telQuery,
        DateTime? fromQuery,
        DateTime? toQuery,
        bool? isActiveQuery, 
        CancellationToken cancellationToken)
    {
        return await DbContext.Contacts
            .Where(x => string.IsNullOrEmpty(nameQuery) || x.FirstName.Contains(nameQuery) || x.LastName.Contains(nameQuery))
            .Where(x => string.IsNullOrEmpty(telQuery) || x.TelephoneNumber.Contains(telQuery))
            .Where(x => !fromQuery.HasValue || x.BirthDate >= fromQuery)
            .Where(x => !toQuery.HasValue || x.BirthDate <= toQuery)
            .Where(x => !isActiveQuery.HasValue || x.IsActive == isActiveQuery)
            .ToListAsync(cancellationToken);
    }
}