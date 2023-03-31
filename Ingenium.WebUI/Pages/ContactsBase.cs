using Ingenium.WebAPI.Contracts.Models;
using Ingenium.WebUI.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace Ingenium.WebUI.Pages;

public class ContactsBase : ComponentBase
{
    [Inject]
    public IContactService ContactService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public List<ContactModel> Contacts { get; set; }

    public string? NameQuery { get; set; }
    public string? TelQuery { get; set; }
    public DateTime? FromQuery { get; set; }
    public DateTime? ToQuery { get; set; }
    public bool? IsActiveQuery { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Contacts = await ContactService.GetAllAsync();
    }

    public async Task SearchAsync()
    {
        Contacts = await ContactService.SearchAsync(NameQuery, TelQuery, FromQuery, ToQuery, IsActiveQuery);
    }   
}