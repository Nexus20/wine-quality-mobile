using Newtonsoft.Json;
using wine_quality_mobile.Models.Results.ProcessParameters;

namespace wine_quality_mobile.Services.Parameters;

public class ParametersService : IParametersService
{
    private readonly HttpClient _httpClient;

    public ParametersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProcessParameterResult>> GetParametersAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("", cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve parameters");

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<List<ProcessParameterResult>>(content);
        return result;
    }

    public async Task<ProcessParameterDetailResult> GetParameterByIdAsync(string parameterId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/{parameterId}", cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve parameter");

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<ProcessParameterDetailResult>(content);
        return result;
    }
}