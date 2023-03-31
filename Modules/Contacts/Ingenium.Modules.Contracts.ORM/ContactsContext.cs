using Ingenium.Modules.Contacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ingenium.Modules.Contacts.ORM;

public sealed class ContactsContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    public ContactsContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactsContext).Assembly);
    }
}