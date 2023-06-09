using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.ProcessPhases;

public class EditPhaseParametersRequest
{
    [Required] public string ProcessPhaseId { get; set; } = null!;
    [Required] public string[] ProcessParametersIdsToAdd { get; set; } = null!;
    [Required] public string[] ProcessParametersIdsToRemove { get; set; } = null!;
}