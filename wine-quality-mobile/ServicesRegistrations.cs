﻿using wine_quality_mobile.Services.GrapeSorts;
using wine_quality_mobile.Services.Parameters;
using wine_quality_mobile.Services.Phases;
using wine_quality_mobile.Services.QualityPrediction;
using wine_quality_mobile.Services.Sensors;
using wine_quality_mobile.Services.SignalR;
using wine_quality_mobile.Services.Users;
using wine_quality_mobile.Services.WineMaterialBatches;
using wine_quality_mobile.States;

namespace wine_quality_mobile;

public static class ServicesRegistrations
{
    private const string ApiBaseAddress = "https://192.168.0.101:7110/api";
    
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddSingleton<AppState>();
        services.AddHttpClient<IPhasesService, PhasesService>((serviceProvider, client) =>
            {
                var appState = serviceProvider.GetRequiredService<AppState>();

                client.BaseAddress = new Uri($"{ApiBaseAddress}/processPhase");

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

                client.BaseAddress = new Uri($"{ApiBaseAddress}/processParameter");

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

                client.BaseAddress = new Uri($"{ApiBaseAddress}/");
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

                client.BaseAddress = new Uri($"{ApiBaseAddress}/");
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });
        
        services.AddHttpClient<IWineMaterialBatchService, WineMaterialBatchService>((serviceProvider, client) =>
            {
                var appState = serviceProvider.GetRequiredService<AppState>();

                if (appState.IsLoggedIn)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {appState.LoginResult!.Token}");
                }

                client.BaseAddress = new Uri($"{ApiBaseAddress}/wineMaterialBatch");
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });
        
        services.AddHttpClient<ISensorService, SensorService>((serviceProvider, client) =>
            {
                var appState = serviceProvider.GetRequiredService<AppState>();

                if (appState.IsLoggedIn)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {appState.LoginResult!.Token}");
                }

                client.BaseAddress = new Uri($"{ApiBaseAddress}/sensor");
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });
        
        services.AddHttpClient<IQualityPredictionService, QualityPredictionService>((serviceProvider, client) =>
            {
                var appState = serviceProvider.GetRequiredService<AppState>();

                if (appState.IsLoggedIn)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {appState.LoginResult!.Token}");
                }

                client.BaseAddress = new Uri($"{ApiBaseAddress}/qualityPrediction");
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });

        services.AddSingleton<ISignalRService, SignalRService>();
        
        return services;
    }
}