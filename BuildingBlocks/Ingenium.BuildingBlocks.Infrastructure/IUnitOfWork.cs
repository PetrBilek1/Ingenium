namespace Ingenium.BuildingBlocks.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync(CancellationToken cancellationToken = default);
}