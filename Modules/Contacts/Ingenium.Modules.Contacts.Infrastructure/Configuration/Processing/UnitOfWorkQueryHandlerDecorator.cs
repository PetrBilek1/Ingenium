using Ingenium.BuildingBlocks.Infrastructure;
using Ingenium.Modules.Contacts.Application.Configuration.Commands;
using Ingenium.Modules.Contacts.Application.Contracts;

namespace Ingenium.Modules.Contacts.Infrastructure.Configuration.Processing;

internal class UnitOfWorkQueryHandlerDecorator<T, TResult> : IQueryHandler<T, TResult>
    where T : IQuery<TResult>
{
    private readonly IQueryHandler<T, TResult> _decorated;
    private readonly IUnitOfWorkProvider _provider;

    public UnitOfWorkQueryHandlerDecorator(IQueryHandler<T, TResult> decorated, IUnitOfWorkProvider provider)
    {
        _decorated = decorated;
        _provider = provider;
    }

    public async Task<TResult> Handle(T query, CancellationToken cancellationToken)
    {
        using var unitOfWork = _provider.CreateUnitOfWork(EntityTrackingOptions.NoTracking);

        var result = await _decorated.Handle(query, cancellationToken);

        return result;
    }
}