using Ingenium.WebAPI.Contracts.Models;
using Ingenium.WebUI.Services.Contracts;
using Ingenium.WebUI.Validation;
using Microsoft.AspNetCore.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ingenium.WebUI.Pages;

public class EditContactBase : ComponentBase
{
    [Inject]
    public IContactService ContactService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string Id { get; set; }

    public ContactModel Contact { get; set; }
    public List<string> Errors { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Contact = await ContactService.GetByIdAsync(Convert.ToInt64(Id));
    }

    public async Task SaveChangesAsync()
    {
        Errors = ContactValidator.Validate(Contact);
        if (Errors.Any())
        {
            return;
        }

        await ContactService.UpdateContactAsync(Contact);

        NavigationManager.NavigateTo("/");
    }
}