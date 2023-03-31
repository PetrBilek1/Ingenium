using Ingenium.Modules.Contacts.ORM;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient(c =>
{
    var optionsBuilder = new DbContextOptionsBuilder<ContactsContext>()
        .UseSqlServer("", options => options
        .EnableRetryOnFailure());
    return new ContactsContext(optionsBuilder.Options);
});

var app = builder.Build();

app.Run();