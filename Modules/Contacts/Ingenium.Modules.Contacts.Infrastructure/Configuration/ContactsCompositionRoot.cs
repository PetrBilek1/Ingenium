using Autofac;

namespace Ingenium.Modules.Contacts.Infrastructure.Configuration;

internal static class ContactsCompositionRoot
{
    private static IContainer? _container;

    internal static void SetContainer(IContainer container)
    {
        _container = container;
    }

    internal static ILifetimeScope BeginLifetimeScope()
    {
        if (_container == null)
        {
            throw new InvalidOperationException("Container was not set.");
        }

        return _container.BeginLifetimeScope();
    }
}