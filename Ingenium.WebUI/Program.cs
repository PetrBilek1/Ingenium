using Ingenium.WebUI;
using Ingenium.WebUI.Services;
using Ingenium.WebUI.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5055/") });

builder.Services.AddScoped<IContactService, ContactService>();

await builder.Build().RunAsync();
