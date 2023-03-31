using Microsoft.AspNetCore.Components;

namespace Ingenium.WebUI.Pages;

public class DisplayErrorsBase : ComponentBase
{
    [Parameter]
    public List<string> Errors { get; set; }
}