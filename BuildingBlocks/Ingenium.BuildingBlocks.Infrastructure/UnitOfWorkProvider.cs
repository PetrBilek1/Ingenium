using Microsoft.EntityFrameworkCore;

namespace Ingenium.BuildingBlocks.Infrastructure;

public sealed class UnitOfWorkProvider<TContext> : IUnitOfWorkProvider
    where TContext : DbContext
{
    private readonly Func<TContext> _dbContextFactory;
    private readonly Stack<UnitOfWork<TContext>> _unitOfWorkStack = new();

    public UnitOfWorkProvider(Func<TContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public IUnitOfWork CreateUnitOfWork()
        => CreateUnitOfWork(EntityTrackingOptions.TrackAll);

    public IUnitOfWork CreateUnitOfWork(EntityTrackingOptions trackingOptions)
        => CreateUnitOfWorkCore(trackingOptions);

    public IUnitOfWork GetCurrentUnitOfWork()
        => _unitOfWorkStack.Peek();

    private IUnitOfWork CreateUnitOfWorkCore(EntityTrackingOptions entityTrackingOptions)
    {
        UnitOfWork<TContext> unitOfWork = CreateUnitOfWork(_dbContextFactory, entityTrackingOptions);

        _unitOfWorkStack.Push(unitOfWork);

        return unitOfWork;
    }

    private UnitOfWork<TContext> CreateUnitOfWork(Func<TContext> dbContextFactory, EntityTrackingOptions entityTrackingOptions)
        => new UnitOfWork<TContext>(dbContextFactory, entityTrackingOptions);
}