namespace Ingenium.BuildingBlocks.Infrastructure.Exceptions;

public sealed class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException() : base() { }
    public ResourceNotFoundException(string message) : base(message) { }
}