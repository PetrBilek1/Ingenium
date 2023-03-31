using Ingenium.BuildingBlocks.Infrastructure;
using Ingenium.Modules.Contacts.Application.Configuration.Commands;
using Ingenium.Modules.Contacts.Application.Contracts;

namespace Ingenium.Modules.Contacts.Infrastructure.Configuration.Processing;

internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult>
    where T : ICommand<TResult>
{
    private readonly ICommandHandler<T, TResult> _decorated;
    private readonly IUnitOfWorkProvider _provider;

    public UnitOfWorkCommandHandlerWithResultDecorator(ICommandHandler<T, TResult> decorated, IUnitOfWorkProvider provider)
    {
        _decorated = decorated;
        _provider = provider;
    }

    public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
    {
        using var unitOfWork = _provider.CreateUnitOfWork();

        var result = await _decorated.Handle(command, cancellationToken);

        await unitOfWork.CommitAsync(cancellationToken);

        return result;
    }
}