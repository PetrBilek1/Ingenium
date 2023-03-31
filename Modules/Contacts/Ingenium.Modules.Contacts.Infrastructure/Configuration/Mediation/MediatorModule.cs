using Autofac;
using Ingenium.Modules.Contacts.Application;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace Ingenium.Modules.Contacts.Infrastructure.Configuration.Mediation;

public sealed class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var configuration = MediatRConfigurationBuilder
            .Create(typeof(IApplicationMarker).Assembly, typeof(IInfrastructureMarker).Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

        builder.RegisterMediatR(configuration);
    }
}