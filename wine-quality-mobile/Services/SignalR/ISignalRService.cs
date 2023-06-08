using wine_quality_mobile.Models.InternalCommunication;

namespace wine_quality_mobile.Services.SignalR;

public interface ISignalRService : IAsyncDisposable
{
    Task ConnectToHubAsync(CancellationToken cancellationToken = default);
    void OnSensorStatusUpdatedMessage(Func<SensorStatusUpdatedMessage, Task> handler);
    void OnReadingsMessage(Func<ReadingsMessage, Task> handler);
    Task DisconnectFromHubAsync(CancellationToken cancellationToken = default);
}