using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.GrapeSorts;

public class AssignGrapeSortToPhaseRequest
{
    [Required] public int Order { get; set; }
    [Required] public string GrapeSortId { get; set; } = null!;
    [Required] public string PhaseId { get; set; } = null!;
    public string? PreviousGrapeSortPhaseId { get; set; }
}