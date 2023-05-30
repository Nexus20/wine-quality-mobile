using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.GrapeSorts;

public class CreateGrapeSortRequest
{
    [Required] public string Name { get; set; } = null!;
}