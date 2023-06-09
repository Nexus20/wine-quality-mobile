using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using wine_quality_mobile.Models.Requests.ProcessParameters;
using wine_quality_mobile.Services.Parameters;

namespace wine_quality_mobile.Pages.Parameters;

public partial class ParameterCreate
{
    [Inject] private IParametersService ParametersService { get; set; }
    
    private CreateProcessParameterRequest CreateProcessParameterRequest { get; set; } = new();

    private async Task CreateParameter(EditContext arg)
    {
        try
        {
            await ParametersService.CreateParameterAsync(CreateProcessParameterRequest);
            NavigationManager.NavigateTo("/Parameters");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}