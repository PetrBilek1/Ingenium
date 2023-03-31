using Ingenium.BuildingBlocks.Infrastructure;
using Ingenium.Modules.Contacts.Application.Configuration.Commands;
using Ingenium.Modules.Contacts.Application.Contracts;

namespace Ingenium.Modules.Contacts.Infrastructure.Configuration.Processing;

internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T>
    where T : ICommand
{
    private readonly ICommandHandler<T> _decorated;
    private readonly IUnitOfWorkProvider _provider;

    public UnitOfWorkCommandHandlerDecorator(ICommandHandler<T> decorated, IUnitOfWorkProvider provider)
    {
        _decorated = decorated;
        _provider = provider;
    }

    public async Task Handle(T command, CancellationToken cancellationToken)
    {
        using var unitOfWork = _provider.CreateUnitOfWork();

        await _decorated.Handle(command, cancellationToken);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}