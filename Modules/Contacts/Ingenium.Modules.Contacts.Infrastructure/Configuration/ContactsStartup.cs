using Autofac;
using Ingenium.Modules.Contacts.Infrastructure.Configuration.DataAccess;
using Ingenium.Modules.Contacts.Infrastructure.Configuration.Mediation;
using Ingenium.Modules.Contacts.Infrastructure.Configuration.Processing;

namespace Ingenium.Modules.Contacts.Infrastructure.Configuration;

public static class ContactsStartup
{
    public static void Initialize(string connectionString)
    {
        ConfigureCompositionRoot(connectionString);
    }

    private static void ConfigureCompositionRoot(string connectionString)
    {
        var containerBuilder = new ContainerBuilder();

        containerBuilder.RegisterModule(new DataAccessModule(connectionString));
        containerBuilder.RegisterModule(new ProcessingModule());
        containerBuilder.RegisterModule(new MediatorModule());

        var container = containerBuilder.Build();

        ContactsCompositionRoot.SetContainer(container);
    }
}