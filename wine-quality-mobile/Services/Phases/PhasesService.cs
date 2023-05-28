using Newtonsoft.Json;
using wine_quality_mobile.Models.Results.ProcessPhases;

namespace wine_quality_mobile.Services.Phases;

public class PhasesService : IPhasesService
{
    private readonly HttpClient _httpClient;

    public PhasesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProcessPhaseResult>> GetPhasesAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("", cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve phases");

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<List<ProcessPhaseResult>>(content);
        return result;
    }

    public async Task<ProcessPhaseDetailResult> GetPhaseByIdAsync(string phaseId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/{phaseId}", cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve phase");

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<ProcessPhaseDetailResult>(content);
        return result;
    }
}