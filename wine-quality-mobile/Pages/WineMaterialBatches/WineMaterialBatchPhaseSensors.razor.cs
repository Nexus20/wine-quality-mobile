using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Enums;
using wine_quality_mobile.Models.Requests.ProcessPhaseParameterSensors;
using wine_quality_mobile.Models.Results.ProcessPhaseParameterSensors;
using wine_quality_mobile.Models.Results.WineMaterialBatches;
using wine_quality_mobile.Services.Sensors;
using wine_quality_mobile.Services.WineMaterialBatches;

namespace wine_quality_mobile.Pages.WineMaterialBatches;

public partial class WineMaterialBatchPhaseSensors
{
    [Parameter]
    public string WineMaterialBatchId { get; set; }
    
    [Parameter]
    public string WineMaterialBatchGrapeSortPhaseId { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "PhaseId")]
    public string PhaseId { get; set; }
    
    [Inject] private ISensorService SensorService { get; set; }
    [Inject] private IWineMaterialBatchService WineMaterialBatchService { get; set; }

    private WineMaterialBatchGrapeSortPhaseResult WineMaterialBatchGrapeSortPhase { get; set; }
    private Dictionary<string, List<ProcessPhaseParameterSensorResult>> AvailableSensorsDictionary { get; set; }
    private Dictionary<string, List<ProcessPhaseParameterSensorResult>> WineMaterialBatchPhaseSensorsDictionary { get; set; }
    private Dictionary<DeviceStatus, string> Statuses { get; set; }
    
    private bool _sensorsLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var request = new GetProcessPhaseParameterSensorsRequest()
            {
                PhaseId = PhaseId
            };
            
            var getPhaseDetailsTask = WineMaterialBatchService.GetPhaseDetailsByIdAsync(WineMaterialBatchGrapeSortPhaseId);
            var getSensorsTask = SensorService.GetAsync(request);
            var getStatusesTask = SensorService.GetStatusesAsync();

            await Task.WhenAll(getPhaseDetailsTask, getSensorsTask, getStatusesTask);
            
            WineMaterialBatchGrapeSortPhase = getPhaseDetailsTask.Result;
            var sensors = getSensorsTask.Result;
            Statuses = getStatusesTask.Result;
            
            
            AvailableSensorsDictionary = sensors.Where(x => string.IsNullOrWhiteSpace(x.WineMaterialBatchGrapeSortPhaseParameterId))
                .GroupBy(x => x.ParameterName)
                .ToDictionary(x => x.Key, x => x.ToList());

            var wineMaterialBatchGrapeSortPhaseParametersIds = WineMaterialBatchGrapeSortPhase.Parameters.Select(x => x.Id).ToList();
            
            WineMaterialBatchPhaseSensorsDictionary = sensors.Where(x => !string.IsNullOrWhiteSpace(x.WineMaterialBatchGrapeSortPhaseParameterId) && wineMaterialBatchGrapeSortPhaseParametersIds.Contains(x.WineMaterialBatchGrapeSortPhaseParameterId))
                .GroupBy(x => x.ParameterName)
                .ToDictionary(x => x.Key, x => x.ToList());

            _sensorsLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }
    
    private async Task OnSubmit()
    {
        Console.WriteLine();
    }
}