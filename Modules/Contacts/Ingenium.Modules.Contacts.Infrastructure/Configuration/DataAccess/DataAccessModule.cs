using Autofac;
using Ingenium.BuildingBlocks.Infrastructure;
using Ingenium.Modules.Contacts.ORM;
using Microsoft.EntityFrameworkCore;

namespace Ingenium.Modules.Contacts.Infrastructure.Configuration.DataAccess;

internal sealed class DataAccessModule : Module
{
    private readonly string _connectionString;

    internal DataAccessModule(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder
            .Register<Func<ContactsContext>>(c => ContactsContextFactory)
            .As<Func<ContactsContext>>()
            .InstancePerLifetimeScope();

        builder
            .RegisterType<UnitOfWorkProvider<ContactsContext>>()
            .As<IUnitOfWorkProvider>()
            .InstancePerLifetimeScope();

        builder
            .RegisterAssemblyTypes(typeof(IInfrastructureMarker).Assembly)
            .Where(type => type.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }

    private ContactsContext ContactsContextFactory()
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ContactsContext>();
        dbContextOptionsBuilder.UseSqlServer(_connectionString);

        return new ContactsContext(dbContextOptionsBuilder.Options);
    }
}