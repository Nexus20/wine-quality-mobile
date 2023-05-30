using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.ProcessPhaseTypes;

public class RemoveParametersFromPhaseRequest
{
    [Required] public string ProcessPhaseId { get; set; } = null!;
    [Required] public string[] ProcessParameterIds { get; set; } = null!;
}