using Autofac;
using Ingenium.Modules.Contacts.Application.Contracts;
using MediatR;

namespace Ingenium.Modules.Contacts.Infrastructure.Configuration;

internal static class CommandsExecutor
{
    internal static async Task Execute(ICommand command)
    {
        using var scope = ContactsCompositionRoot.BeginLifetimeScope();

        var mediator = scope.Resolve<IMediator>();

        await mediator.Send(command);
    }

    internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
    {
        using var scope = ContactsCompositionRoot.BeginLifetimeScope();

        var mediator = scope.Resolve<IMediator>();

        return await mediator.Send(command);
    }
}