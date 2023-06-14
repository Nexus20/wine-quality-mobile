using wine_quality_mobile.Enums;
using wine_quality_mobile.Models.Requests.ProcessPhaseParameterSensors;
using wine_quality_mobile.Models.Results.ProcessPhaseParameterSensors;

namespace wine_quality_mobile.Services.Sensors;

public interface ISensorService
{
    Task<List<ProcessPhaseParameterSensorResult>> GetAsync(GetProcessPhaseParameterSensorsRequest request, CancellationToken cancellationToken = default);
    Task<ProcessPhaseParameterSensorResult> GetByIdAsync(string sensorId, CancellationToken cancellationToken = default);
    Task<Dictionary<DeviceStatus, string>> GetStatusesAsync(CancellationToken cancellationToken = default);
    Task DeleteAsync(string sensorId, CancellationToken cancellationToken = default);
    Task CreateAsync(CreateProcessPhaseParameterSensorRequest createSensorRequest, CancellationToken cancellationToken = default);
}