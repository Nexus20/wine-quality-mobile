using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.GrapeSorts;

public class AddGrapeSortPhaseForecastModelDatasetsRequest
{
    [Required] public string GrapeSortPhaseId { get; set; } = null!;
}