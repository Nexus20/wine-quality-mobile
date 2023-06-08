using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using wine_quality_mobile.Enums;
using wine_quality_mobile.Models.Requests.ProcessPhaseParameterSensors;
using wine_quality_mobile.Models.Results.ProcessPhaseParameterSensors;

namespace wine_quality_mobile.Services.Sensors;

public class SensorService : ISensorService
{
    private readonly HttpClient _httpClient;

    public SensorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProcessPhaseParameterSensorResult>> GetAsync(GetProcessPhaseParameterSensorsRequest request, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{_httpClient.BaseAddress}";
        
        if(!string.IsNullOrWhiteSpace(request.PhaseId))
            requestUri += $"?PhaseId={request.PhaseId}";
        
        var response = await _httpClient.GetAsync(requestUri, cancellationToken);
        
        if(!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve sensors");
        
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<List<ProcessPhaseParameterSensorResult>>(json);
        return result;
    }

    public async Task<Dictionary<DeviceStatus, string>> GetStatusesAsync(CancellationToken cancellationToken = default)
    {
        var requestUri = $"{_httpClient.BaseAddress}/statuses";
        
        var response = await _httpClient.GetAsync(requestUri, cancellationToken);
        
        if(!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve statuses");
        
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var jArray = JArray.Parse(json);
        var result = jArray.ToDictionary(x => (DeviceStatus)int.Parse(x["status"].ToString()), x => x["value"].ToString());
        return result;
    }
}