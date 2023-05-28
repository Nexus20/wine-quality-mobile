using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Requests.Auth;
using wine_quality_mobile.Services.Users;

namespace wine_quality_mobile.Pages.Auth
{
    public partial class Login
    {
        [Inject] private IUsersService UserService { get; set; } = null!;

        public LoginRequest LoginModel { get; set; } = new LoginRequest()
        {
            Email = "root@wine-quality.com",
            Password = "_QGrXyvcmTD4aVQJ_",
        };

        public async Task OnSubmitAsync()
        {
            try
            {
                await UserService.LoginAsync(LoginModel);
                NavigationManager.NavigateTo("/", true);
            }
            catch (Exception ex)
            {
                //AddError(ex);
            }
        }
    }
}
