using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.Users;

public class UpdateUserRequest
{
    [Required] public string Id { get; set; } = null!;
    [Required] public string FirstName { get; set; } = null!;
    [Required] public string LastName { get; set; } = null!;
    [Required] public string Phone { get; set; } = null!;
}