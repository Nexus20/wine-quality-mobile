using wine_quality_mobile.Models.Requests.Auth;
using wine_quality_mobile.Models.Results.Auth;

namespace wine_quality_mobile.Services.Users;

public interface IUsersService
{
    Task<LoginResult> LoginAsync(LoginRequest requestBody);
}