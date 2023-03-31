using Ingenium.WebAPI.Contracts.Models;
using Ingenium.WebUI.Services;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace Ingenium.WebUI.Pages;

public class ContactEditorBase : ComponentBase
{
    [Parameter]
    public ContactModel Contact { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Contact.TelephoneNumber = TelephoneNumberFormated(Contact.TelephoneNumber);
    }

    public async Task TelephoneNumberChanged(ChangeEventArgs e)
    {
        if (e.Value == null)
        {
            return;
        }

        Contact.TelephoneNumber = TelephoneNumberFormated(e.Value.ToString()!);
    }

    public static string TelephoneNumberFormated(string number)
    {
        var numberBasic = number.Trim().Replace(" ", "");
        StringBuilder builder = new(20);

        short index = 0;
        foreach (char c in numberBasic)
        {
            if (index % 3 == 0 && index > 0 && c != ' ')
            {
                builder.Append($" {c}");
            }
            else
            {
                builder.Append(c);
            }

            if (c != '+')
            {
                index++;
            }
        }

        return builder.ToString();
    }
}