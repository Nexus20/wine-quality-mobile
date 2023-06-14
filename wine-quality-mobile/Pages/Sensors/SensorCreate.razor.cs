using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Requests.ProcessPhaseParameterSensors;
using wine_quality_mobile.Models.Results.ProcessParameters;
using wine_quality_mobile.Models.Results.ProcessPhases;
using wine_quality_mobile.Services.Parameters;
using wine_quality_mobile.Services.Phases;
using wine_quality_mobile.Services.Sensors;

namespace wine_quality_mobile.Pages.Sensors;

public partial class SensorCreate
{
    [Inject] private IPhasesService PhasesService { get; set; } = null!;
    [Inject] private IParametersService ParametersService { get; set; } = null!;
    [Inject] private ISensorService SensorService { get; set; } = null!; 
    
    private List<ProcessPhaseResult> _phases = new();
    private List<ProcessParameterResult> _parameters = new();
    
    private readonly CreateProcessPhaseParameterSensorRequest _createSensorRequest = new();
    
    private bool _dataLoaded;
    
    protected override async Task<Task> OnInitializedAsync()
    {
        try
        {
            var phasesTask = PhasesService.GetPhasesAsync();
            var parametersTask = ParametersService.GetParametersAsync();
            
            await Task.WhenAll(phasesTask, parametersTask);
            
            _phases = phasesTask.Result;
            _parameters = parametersTask.Result;
            
            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return base.OnInitializedAsync();
    }
    
    private async Task CreateSensorAsync()
    {
        try
        {
            await SensorService.CreateAsync(_createSensorRequest);
            NavigationManager.NavigateTo("/Sensors");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}