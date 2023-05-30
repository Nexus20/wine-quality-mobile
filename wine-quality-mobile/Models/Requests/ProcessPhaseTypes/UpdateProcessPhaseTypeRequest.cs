using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.ProcessPhaseTypes;

public class UpdateProcessPhaseRequest
{
    [Required] public string Id { get; set; } = null!;
    [Required] public string Name { get; set; } = null!;
}