using Ingenium.Modules.Contacts.Application.Contracts;
using MediatR;

namespace Ingenium.Modules.Contacts.Application.Configuration.Commands;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}