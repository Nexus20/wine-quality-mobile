using wine_quality_mobile.Enums;
using wine_quality_mobile.Models.Results.Abstract;

namespace wine_quality_mobile.Models.Results.ProcessPhaseParameterSensors;

public class ProcessPhaseParameterSensorResult : BaseResult
{
    public string PhaseParameterId { get; set; } = null!;
    public string PhaseId { get; set; } = null!;
    public string PhaseName { get; set; } = null!;
    public string ParameterId { get; set; } = null!;
    public string ParameterName { get; set; } = null!;
    
    public string WineMaterialBatchGrapeSortPhaseParameterId { get; set; }
    public string WineBatchId { get; set; }
    public string WineBatchName { get; set; }

    public string DeviceKey { get; set; } = null!;
    public bool IsActive { get; set; }
    public DeviceStatus Status { get; set; }
    
    public double? LastValue { get; set; }
}