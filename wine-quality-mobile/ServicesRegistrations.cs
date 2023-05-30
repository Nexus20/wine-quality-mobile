using wine_quality_mobile.Services.GrapeSorts;
using wine_quality_mobile.Services.Parameters;
using wine_quality_mobile.Services.Phases;
using wine_quality_mobile.Services.Users;
using wine_quality_mobile.States;

namespace wine_quality_mobile;

public static class ServicesRegistrations
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddSingleton<AppState>();
        services.AddHttpClient<IPhasesService, PhasesService>((serviceProvider, client) =>
            {
                var appState = serviceProvider.GetRequiredService<AppState>();

                client.BaseAddress = new Uri("https://192.168.0.111:7110/api/processPhase");

                if (appState.IsLoggedIn)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {appState.LoginResult!.Token}");
                }
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });
        
        services.AddHttpClient<IParametersService, ParametersService>((serviceProvider, client) =>
            {
                var appState = serviceProvider.GetRequiredService<AppState>();

                client.BaseAddress = new Uri("https://192.168.0.111:7110/api/processParameter");

                if (appState.IsLoggedIn)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {appState.LoginResult!.Token}");
                }
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });

        services.AddHttpClient<IUsersService, UsersService>((serviceProvider, client) =>
            {
                var appState = serviceProvider.GetRequiredService<AppState>();

                if (appState.IsLoggedIn)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {appState.LoginResult!.Token}");
                }

                client.BaseAddress = new Uri("https://192.168.0.111:7110/api/");
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });
        
        services.AddHttpClient<IGrapeSortsService, GrapeSortsService>((serviceProvider, client) =>
            {
                var appState = serviceProvider.GetRequiredService<AppState>();

                if (appState.IsLoggedIn)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {appState.LoginResult!.Token}");
                }

                client.BaseAddress = new Uri("https://192.168.0.111:7110/api/");
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });

        return services;
    }
}