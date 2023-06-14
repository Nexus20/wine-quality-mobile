using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Enums;
using wine_quality_mobile.Models.Requests.ProcessPhaseParameterSensors;
using wine_quality_mobile.Models.Results.ProcessPhaseParameterSensors;
using wine_quality_mobile.Services.Sensors;

namespace wine_quality_mobile.Pages.Sensors;

public partial class Sensors
{
    [Inject] private ISensorService SensorService { get; set; } = null!;
    
    private List<ProcessPhaseParameterSensorResult> _sensors = new();
    private Dictionary<DeviceStatus, string> _statuses;
    private bool _dataLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var sensorsTask = SensorService.GetAsync(new GetProcessPhaseParameterSensorsRequest());
            var statusesTask = SensorService.GetStatusesAsync();

            await Task.WhenAll(sensorsTask, statusesTask);
            
            _sensors = sensorsTask.Result;
            _statuses = statusesTask.Result;
            
            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }

    private void CopyDeviceId(string deviceId)
    {
        
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Clipboard.Default.SetTextAsync(null);
            Clipboard.Default.SetTextAsync(deviceId);
        });
    }
    
    private void CopyDeviceKey(string deviceKey)
    {
        
        MainThread.BeginInvokeOnMainThread(() => 
        {
            Clipboard.Default.SetTextAsync(null);
            Clipboard.Default.SetTextAsync(deviceKey);
        });
    }
}