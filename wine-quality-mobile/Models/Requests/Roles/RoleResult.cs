using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.Roles;

public class CreateRoleRequest
{
    [Required] public string Name { get; set; } = null!;
}