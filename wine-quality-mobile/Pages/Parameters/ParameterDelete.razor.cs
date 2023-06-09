using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.ProcessParameters;
using wine_quality_mobile.Services.Parameters;

namespace wine_quality_mobile.Pages.Parameters;

public partial class ParameterDelete
{
    [Parameter]
    public string ParameterId { get; set; }
    
    private ProcessParameterResult Parameter { get; set; }
    private bool _parameterLoaded;
    
    [Inject]
    private IParametersService ParametersService { get; set; }

    protected override async Task<Task> OnInitializedAsync()
    {
        try
        {
            Parameter = await ParametersService.GetParameterByIdAsync(ParameterId);
            _parameterLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return base.OnInitializedAsync();
    }

    private async Task DeleteParameter()
    {
        try
        {
            await ParametersService.DeleteProcessParameterAsync(ParameterId);
            NavigationManager.NavigateTo("/Parameters");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}