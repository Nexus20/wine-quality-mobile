using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.ProcessParameters;
using wine_quality_mobile.Services.Parameters;

namespace wine_quality_mobile.Pages.Parameters;

public partial class Parameter
{
    [Parameter] public string ParameterId { get; set; } = null!;

    [Inject] private IParametersService ParametersService { get; set; } = null!;

    private ProcessParameterDetailResult _parameter;
    private bool _parameterLoaded = false;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _parameter = await ParametersService.GetParameterByIdAsync(ParameterId);
            _parameterLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        await base.OnInitializedAsync();
    }
}