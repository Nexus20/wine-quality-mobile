using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.ProcessPhaseParameterSensors;
using wine_quality_mobile.Services.Sensors;

namespace wine_quality_mobile.Pages.Sensors;

public partial class SensorDelete
{
    [Parameter] public string SensorId { get; set; }
    [Inject] private ISensorService SensorService { get; set; } = null!;

    private ProcessPhaseParameterSensorResult _sensor;
    private bool _dataLoaded;
    
    protected override async Task<Task> OnInitializedAsync()
    {
        try
        {
            _sensor = await SensorService.GetByIdAsync(SensorId);
            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return base.OnInitializedAsync();
    }
    
    private async Task DeleteSensor()
    {
        try
        {
            await SensorService.DeleteAsync(SensorId);
            NavigationManager.NavigateTo("/Sensors");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}