using Ingenium.WebAPI.Contracts.Models;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace Ingenium.WebUI.Pages;

public class DisplayContactsBase : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public List<ContactModel> Contacts { get; set; }

    public static string TelephoneNumberFormated(ContactModel contact)
    {
        StringBuilder builder = new(20);

        short index = 0;
        foreach (char c in contact.TelephoneNumber)
        {
            builder.Append(index % 3 == 0 && index > 0 ? $" {c}" : c);

            if (c != '+')
            {
                index++;
            }
        }

        return builder.ToString();
    }
}