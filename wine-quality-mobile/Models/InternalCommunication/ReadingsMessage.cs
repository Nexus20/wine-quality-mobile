using wine_quality_mobile.Models.Results.WineMaterialBatches;

namespace wine_quality_mobile.Models.InternalCommunication;

public class ReadingsMessage
{
    public string DeviceId { get; set; }
    public WineMaterialBatchGrapeSortPhaseParameterValueResult Value { get; set; }
}