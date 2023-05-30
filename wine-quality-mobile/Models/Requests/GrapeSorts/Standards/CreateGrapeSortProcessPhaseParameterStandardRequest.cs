using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.GrapeSorts.Standards;

public class CreateGrapeSortProcessPhaseParameterStandardRequest
{
    public double? LowerBound { get; set; }
    public double? UpperBound { get; set; }
    
    [Required] public string GrapeSortPhaseId { get; set; } = null!;
    [Required] public string ParameterId { get; set; } = null!;
}