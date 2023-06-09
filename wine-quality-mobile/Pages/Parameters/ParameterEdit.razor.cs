using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using wine_quality_mobile.Models.Requests.ProcessParameters;
using wine_quality_mobile.Models.Results.ProcessParameters;
using wine_quality_mobile.Services.Parameters;

namespace wine_quality_mobile.Pages.Parameters;

public partial class ParameterEdit
{
    [Parameter]
    public string ParameterId { get; set; }
    
    public ProcessParameterResult Parameter { get; set; }
    
    [Inject]
    private IParametersService ParametersService { get; set; }
    
    private UpdateProcessParameterRequest UpdateProcessParameterRequest { get; set; }
    
    private bool _parameterLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Parameter = await ParametersService.GetParameterByIdAsync(ParameterId);
            
            UpdateProcessParameterRequest = new UpdateProcessParameterRequest
            {
                Id = ParameterId,
                Name = Parameter.Name
            };
            _parameterLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }

    private async Task EditParameter(EditContext arg)
    {
        try
        {
            await ParametersService.UpdateProcessParameterAsync(UpdateProcessParameterRequest);
            NavigationManager.NavigateTo("/Parameters");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}