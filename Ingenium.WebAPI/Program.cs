using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ingenium.Modules.Contacts.Infrastructure.Configuration;
using Ingenium.WebAPI.Modules.Contacts;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(ConfigureContainer);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string contactsConnectionString = builder.Configuration.GetConnectionString("ContactsConnection") ?? string.Empty;

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

InitializeModules(contactsConnectionString);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

static void InitializeModules(string contactsConnectionString)
{
    ContactsStartup.Initialize(contactsConnectionString);
    ContactsMigrator.ApplyMigrations();
}

static void ConfigureContainer(ContainerBuilder containerBuilder)
{
    containerBuilder.RegisterModule(new ContactsAutofacModule());
}