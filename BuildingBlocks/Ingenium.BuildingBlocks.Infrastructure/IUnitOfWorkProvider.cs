namespace Ingenium.BuildingBlocks.Infrastructure;

public interface IUnitOfWorkProvider
{
    IUnitOfWork CreateUnitOfWork();
    IUnitOfWork CreateUnitOfWork(EntityTrackingOptions trackingOptions);
    IUnitOfWork GetCurrentUnitOfWork();
}