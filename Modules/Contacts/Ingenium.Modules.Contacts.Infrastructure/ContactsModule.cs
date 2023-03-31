using Autofac;
using Ingenium.Modules.Contacts.Application.Contracts;
using Ingenium.Modules.Contacts.Infrastructure.Configuration;
using MediatR;

namespace Ingenium.Modules.Contacts.Infrastructure;

public sealed class ContactsModule : IContactsModule
{
    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
    {
        return await CommandsExecutor.Execute(command);
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        await CommandsExecutor.Execute(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using var scope = ContactsCompositionRoot.BeginLifetimeScope();

        var mediator = scope.Resolve<IMediator>();

        return await mediator.Send(query);
    }
}
