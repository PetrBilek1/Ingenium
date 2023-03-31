using Microsoft.EntityFrameworkCore;

namespace Ingenium.BuildingBlocks.Infrastructure;

public abstract class RepositoryBase<TContext>
    where TContext : DbContext
{
    private readonly IUnitOfWorkProvider _provider;

    protected RepositoryBase(IUnitOfWorkProvider provider)
    {
        _provider = provider;
    }

    protected TContext DbContext => UnitOfWork<TContext>.TryGetDbContext(_provider);
}