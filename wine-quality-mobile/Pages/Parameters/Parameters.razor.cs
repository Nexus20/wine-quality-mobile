using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.ProcessParameters;
using wine_quality_mobile.Services.Parameters;

namespace wine_quality_mobile.Pages.Parameters;

public partial class Parameters
{
    [Inject] private IParametersService ParameterService { get; set; } = null!;

    private List<ProcessParameterResult> parameters { get; set; } = new();
    private bool parametersLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            parameters = await ParameterService.GetParametersAsync();
            parametersLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}