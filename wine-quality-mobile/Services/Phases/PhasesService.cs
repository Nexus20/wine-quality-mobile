using System.Text;
using Newtonsoft.Json;
using wine_quality_mobile.Models.Requests.ProcessPhases;
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

    public async Task CreatePhaseAsync(CreateProcessPhaseRequest createProcessPhaseRequest, CancellationToken cancellationToken = default)
    {
        var json = JsonConvert.SerializeObject(createProcessPhaseRequest);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("", data, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to create phase");
    }

    public async Task UpdateProcessPhaseAsync(UpdateProcessPhaseRequest updateProcessPhaseRequest, CancellationToken cancellationToken = default)
    {
        var json = JsonConvert.SerializeObject(updateProcessPhaseRequest);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"{_httpClient.BaseAddress}/{updateProcessPhaseRequest.Id}", data, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to update phase");
    }
    
    public async Task DeleteProcessPhaseAsync(string phaseId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}/{phaseId}", cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to delete phase");
    }

    public async Task EditPhaseParametersAsync(EditPhaseParametersRequest request, CancellationToken cancellationToken = default)
    {
        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}/edit_parameters", data, cancellationToken);
        
        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to edit phase parameters");
    }
}