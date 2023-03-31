using Autofac;
using Ingenium.Modules.Contacts.Application.Contracts;
using Ingenium.Modules.Contacts.Infrastructure;

namespace Ingenium.WebAPI.Modules.Contacts;

public class ContactsAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ContactsModule>()
            .As<IContactsModule>()
            .InstancePerLifetimeScope();
    }
}