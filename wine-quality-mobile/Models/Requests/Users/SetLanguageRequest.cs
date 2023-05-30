using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.Users;

public class SetLanguageRequest
{
    [Required] public string NewLanguage { get; set; } = null!;
}