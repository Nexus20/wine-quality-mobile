using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.ProcessParameters;

public class CreateProcessParameterRequest
{
    [Required] public string Name { get; set; } = null!;
}