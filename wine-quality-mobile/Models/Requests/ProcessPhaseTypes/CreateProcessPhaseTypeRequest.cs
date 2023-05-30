using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.ProcessPhaseTypes;

public class CreateProcessPhaseRequest
{
    [Required] public string Name { get; set; } = null!;
}