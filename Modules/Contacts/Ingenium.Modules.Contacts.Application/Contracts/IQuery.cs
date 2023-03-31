using MediatR;

namespace Ingenium.Modules.Contacts.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}