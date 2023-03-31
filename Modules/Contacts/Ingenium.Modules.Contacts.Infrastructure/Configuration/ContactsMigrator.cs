using Autofac;
using Ingenium.Modules.Contacts.ORM;
using Microsoft.EntityFrameworkCore;

namespace Ingenium.Modules.Contacts.Infrastructure.Configuration;

public static class ContactsMigrator
{
    public static void ApplyMigrations()
    {
        using var scope = ContactsCompositionRoot.BeginLifetimeScope();

        var context = scope.Resolve<Func<ContactsContext>>()();

        context.Database.MigrateAsync().GetAwaiter().GetResult();
    }
}