using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.GrapeSorts;

public class UpdateGrapeSortRequest
{
    [Required] public string Id { get; set; } = null!;
    [Required] public string Name { get; set; } = null!;
}