using Ingenium.WebAPI.Contracts.Models;
using Ingenium.WebUI.Services.Contracts;
using Ingenium.WebUI.Validation;
using Microsoft.AspNetCore.Components;

namespace Ingenium.WebUI.Pages;

public class CreateContactBase : ComponentBase
{
    [Inject]
    public IContactService ContactService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public ContactModel Contact { get; set; } = new();
    public List<string> Errors { get; set; } = new();

    public async Task SaveChangesAsync()
    {
        Errors = ContactValidator.Validate(Contact);
        if (Errors.Any())
        {
            return;
        }

        await ContactService.CreateContactAsync(Contact);

        NavigationManager.NavigateTo("/");
    }
}