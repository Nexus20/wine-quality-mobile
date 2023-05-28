using System.Text;
using Newtonsoft.Json;
using wine_quality_mobile.Models.Requests.Auth;
using wine_quality_mobile.Models.Results.Auth;
using wine_quality_mobile.States;

namespace wine_quality_mobile.Services.Users;

public class UsersService : IUsersService
{
    private readonly HttpClient _httpClient;
    private readonly AppState _appState;

    public UsersService(HttpClient httpClient, AppState appState)
    {
        _httpClient = httpClient;
        _appState = appState;
    }

    public async Task<LoginResult> LoginAsync(LoginRequest requestBody)
    {
        var uri = "auth/login";
        var json = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(uri, content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception();
        }

        var responseContent = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(responseContent))
        {
            throw new Exception();
        }

        var result = JsonConvert.DeserializeObject<LoginResult>(responseContent);

        if (result.IsAuthSuccessful)
        {
            _appState.SetLoginResult(result);
        }

        return result;
    }
}