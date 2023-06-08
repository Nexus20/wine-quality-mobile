using Microsoft.AspNetCore.SignalR.Client;
using wine_quality_mobile.Constants;
using wine_quality_mobile.Models.InternalCommunication;

namespace wine_quality_mobile.Services.SignalR;

public class SignalRService : ISignalRService
{
    private readonly HubConnection _hubConnection;
    private bool _isConnectedToHub;

    public SignalRService()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://192.168.0.101:7110/wine-quality", opts => {
                opts.HttpMessageHandlerFactory = message =>
                {
                    if (message is HttpClientHandler clientHandler)
                        clientHandler.ServerCertificateCustomValidationCallback =
                            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                    return message;
                };
            })
            .WithAutomaticReconnect()
            .Build();
    }
    
    public async Task ConnectToHubAsync(CancellationToken cancellationToken = default) {

        if (_isConnectedToHub)
            return;

        try {
            await _hubConnection.StartAsync(cancellationToken);
            Console.WriteLine("Connected to hub");

            _isConnectedToHub = true;
        }
        catch (Exception ex) {
            Console.WriteLine($"Hub connection error: {ex.Message}");
        }
    }
    
    public void OnSensorStatusUpdatedMessage(Func<SensorStatusUpdatedMessage, Task> handler) {
        _hubConnection.On(SignalRMessages.SensorStatusUpdatedMessage, handler);
    }

    public void OnReadingsMessage(Func<ReadingsMessage, Task> handler) {
        _hubConnection.On(SignalRMessages.ReadingsMessage, handler);
    }
    
    public async Task DisconnectFromHubAsync(CancellationToken cancellationToken = default) {

        if (!_isConnectedToHub) return;

        await _hubConnection.StopAsync(cancellationToken);
        _isConnectedToHub = false;
        Console.WriteLine("Disconnected from hub");
    }

    public ValueTask DisposeAsync()
    {
        return _hubConnection.DisposeAsync();
    }
}