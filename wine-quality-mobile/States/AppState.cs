using wine_quality_mobile.Models.Results.Auth;

namespace wine_quality_mobile.States;

public class AppState
{
    public LoginResult LoginResult { get; private set; }

    public event Action OnChange;

    public void SetLoginResult(LoginResult result)
    {
        LoginResult = result;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();

    public bool IsLoggedIn => LoginResult is { IsAuthSuccessful: true };
    
    public static string[] AvailableCultures { get; } = { "en-US", "uk-UA" };
    public static string CurrentCulture { get; set; } = "en-US";
}