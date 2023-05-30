using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.ProcessPhaseParameterSensors;

public class CreateProcessPhaseParameterSensorRequest
{
    [Required] public string PhaseId { get; set; } = null!;
    [Required] public string ParameterId { get; set; } = null!;
}