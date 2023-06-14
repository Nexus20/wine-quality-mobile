using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using wine_quality_mobile.Components;
using wine_quality_mobile.Enums;
using wine_quality_mobile.Models.Results.WineMaterialBatches;
using wine_quality_mobile.Services.Sensors;
using wine_quality_mobile.Services.SignalR;
using wine_quality_mobile.Services.WineMaterialBatches;

namespace wine_quality_mobile.Pages.WineMaterialBatches;

public partial class WineMaterialBatchPhaseDetails
{
    [Parameter]
    public string WineMaterialBatchId { get; set; }
    
    [Parameter]
    public string WineMaterialBatchGrapeSortPhaseId { get; set; }

    [Inject] private ISensorService SensorService { get; set; }
    [Inject] private IWineMaterialBatchService WineMaterialBatchService { get; set; }
    [Inject] private ISignalRService SignalRService { get; set; }

    private WineMaterialBatchDetailsResult WineMaterialBatchDetails { get; set; }
    private WineMaterialBatchGrapeSortPhaseDetailsResult WineMaterialBatchGrapeSortPhase { get; set; }
    private Dictionary<DeviceStatus, string> Statuses { get; set; }

    private bool _wineMaterialBatchGrapeSortPhaseLoaded;

    private ChartDialog _chartDialogRef;
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            var statusesTask = SensorService.GetStatusesAsync();
            var wineMaterialBatchDetailsTask = WineMaterialBatchService.GetDetailsByIdAsync(WineMaterialBatchId);
            var wineMaterialBatchGrapeSortPhaseTask = WineMaterialBatchService.GetPhaseDetailsByIdAsync(WineMaterialBatchGrapeSortPhaseId);

            await Task.WhenAll(statusesTask, wineMaterialBatchDetailsTask, wineMaterialBatchGrapeSortPhaseTask);
            
            Statuses = statusesTask.Result;
            WineMaterialBatchDetails = wineMaterialBatchDetailsTask.Result;
            WineMaterialBatchGrapeSortPhase = wineMaterialBatchGrapeSortPhaseTask.Result;

            await SignalRService.ConnectToHubAsync();
            
            SignalRService.OnSensorStatusUpdatedMessage(async message =>
            {
                foreach (var wineMaterialBatchGrapeSortPhaseParameter in WineMaterialBatchGrapeSortPhase.ParametersDetails)
                {
                    var sensor = wineMaterialBatchGrapeSortPhaseParameter.Sensors.SingleOrDefault(s => s.Id == message.DeviceId);

                    if (sensor == null) continue;
                    sensor.Status = message.NewStatus;
                    break;
                }
                
                await InvokeAsync(StateHasChanged);
            });
            
            SignalRService.OnReadingsMessage(async message =>
            {
                foreach (var wineMaterialBatchGrapeSortPhaseParameter in WineMaterialBatchGrapeSortPhase.ParametersDetails)
                {
                    var sensor = wineMaterialBatchGrapeSortPhaseParameter.Sensors.SingleOrDefault(s => s.Id == message.DeviceId);

                    if (sensor == null) continue;
                    sensor.LastValue = message.Value.Value;
                    break;
                }
                
                await InvokeAsync(StateHasChanged);
            });
            
            _wineMaterialBatchGrapeSortPhaseLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }

    public async ValueTask DisposeAsync()
    {
        // await SignalRService.DisconnectFromHubAsync();
        // await SignalRService.DisposeAsync();
    }

    private async Task OpenChartDialog(WineMaterialBatchGrapeSortPhaseParameterDetailsResult parameter)
    {
        await _chartDialogRef.Show(parameter);
    }
}