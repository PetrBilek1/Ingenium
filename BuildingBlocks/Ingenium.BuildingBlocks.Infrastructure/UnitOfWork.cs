using Microsoft.EntityFrameworkCore;

namespace Ingenium.BuildingBlocks.Infrastructure;

public sealed class UnitOfWork<TContext> : IUnitOfWork
    where TContext : DbContext
{
    private readonly bool _hasOwnContext;
    private readonly EntityTrackingOptions _trackingOptions;

    public TContext Context { get; }

    public UnitOfWork(Func<TContext> contextFactory, EntityTrackingOptions trackingOptions)
    {
        _trackingOptions = trackingOptions;

        Context = contextFactory();

        if (trackingOptions is EntityTrackingOptions.NoTracking)
        {
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        _hasOwnContext = true;
    }

    public void Dispose()
    {
        Context.Dispose();
    }

    public Task CommitAsync(CancellationToken cancellationToken = default)
        => _hasOwnContext ? CommitCoreAsync() : Task.CompletedTask;

    public static TContext TryGetDbContext(IUnitOfWorkProvider provider)
    {
        IUnitOfWork currentUnitOfWork = provider.GetCurrentUnitOfWork();
        if (currentUnitOfWork == null)
            throw new InvalidOperationException("Current UnitOfWork is null!");

        if (!(currentUnitOfWork is UnitOfWork<TContext> unit))
            throw new InvalidOperationException($"Current UnitOfWork from input provider is other than '{typeof(UnitOfWork<TContext>).Name}'");

        return unit.Context;
    }

    private Task CommitCoreAsync()
    {
        if (_trackingOptions is not EntityTrackingOptions.TrackAll)
            throw new InvalidOperationException($"Can not call commit when {_trackingOptions} query behavior!");

        return Context.SaveChangesAsync();
    }
}