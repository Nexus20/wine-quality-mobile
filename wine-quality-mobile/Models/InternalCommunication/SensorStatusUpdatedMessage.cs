using wine_quality_mobile.Enums;

namespace wine_quality_mobile.Models.InternalCommunication;

public class SensorStatusUpdatedMessage
{
    public string DeviceId { get; set; } = null!;
    public DeviceStatus NewStatus { get; set; }
}