using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.ProcessPhaseTypes;

public class AddParametersToPhaseRequest
{
    [Required] public string ProcessPhaseId { get; set; } = null!;
    [Required] public string[] ProcessParameterIds { get; set; } = null!;
}