using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.ProcessParameters;

public class UpdateProcessParameterRequest
{
    [Required] public string Id { get; set; } = null!;
    [Required] public string Name { get; set; } = null!;
}