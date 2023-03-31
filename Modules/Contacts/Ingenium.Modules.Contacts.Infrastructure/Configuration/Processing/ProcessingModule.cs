using Autofac;
using Ingenium.Modules.Contacts.Application.Configuration.Commands;
using MediatR;

namespace Ingenium.Modules.Contacts.Infrastructure.Configuration.Processing;

internal class ProcessingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGenericDecorator(
            typeof(UnitOfWorkCommandHandlerDecorator<>),
            typeof(IRequestHandler<>),
            context =>
            {
                return context.ImplementationType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICommandHandler<>));
            });

        builder.RegisterGenericDecorator(
            typeof(UnitOfWorkCommandHandlerWithResultDecorator<,>),
            typeof(IRequestHandler<,>),
            context =>
            {
                return context.ImplementationType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICommandHandler<,>));
            });

        builder.RegisterGenericDecorator(
            typeof(UnitOfWorkQueryHandlerDecorator<,>),
            typeof(IRequestHandler<,>),
            context =>
            {
                return context.ImplementationType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IQueryHandler<,>));
            });
    }
}