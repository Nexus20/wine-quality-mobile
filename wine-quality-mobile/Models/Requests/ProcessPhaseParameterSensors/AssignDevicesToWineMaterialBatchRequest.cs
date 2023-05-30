using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.ProcessPhaseParameterSensors;

public class AssignDevicesToWineMaterialBatchRequest
{
    [Required] public string[] SensorsIds { get; set; } = null!;
    [Required] public string WineMaterialBatchGrapeSortPhaseId { get; set; } = null!;
}