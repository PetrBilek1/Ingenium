using MediatR;

namespace Ingenium.Modules.Contacts.Application.Contracts;

public interface ICommand<out TResult> : IRequest<TResult>
{
}

public interface ICommand : IRequest
{
}