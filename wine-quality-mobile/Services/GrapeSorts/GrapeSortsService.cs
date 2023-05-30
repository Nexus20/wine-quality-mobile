﻿using System.Text;
using Newtonsoft.Json;
using wine_quality_mobile.Models.Requests.GrapeSorts.Standards;
using wine_quality_mobile.Models.Results.GrapeSorts;
using wine_quality_mobile.Models.Results.GrapeSorts.Standards;

namespace wine_quality_mobile.Services.GrapeSorts;

public class GrapeSortsService : IGrapeSortsService
{
    private readonly HttpClient _httpClient;

    public GrapeSortsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<GrapeSortResult>> GetGrapeSortsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}GrapeSort", cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve sorts");

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<List<GrapeSortResult>>(content);
        return result;
    }

    public async Task<GrapeSortDetailsResult> GetGrapeSortByIdAsync(string grapeSortId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}GrapeSort/{grapeSortId}", cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve sorts");

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<GrapeSortDetailsResult>(content);
        return result;
    }

    public async Task CreatePhaseParameterStandardAsync(CreateGrapeSortProcessPhaseParameterStandardRequest request, CancellationToken cancellationToken = default)
    {
        var json = JsonConvert.SerializeObject(request);
        var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}GrapeSort/create_standard", requestContent, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to create standard");
    }

    public async Task<GrapeSortProcessPhaseParameterStandardResult> GetStandardByIdAsync(string standardId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}GrapeSort/standards/{standardId}", cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve standard");

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<GrapeSortProcessPhaseParameterStandardResult>(content);
        return result;
    }

    public async Task UpdateStandardAsync(UpdateGrapeSortProcessPhaseParameterStandardsRequestPart request,
        CancellationToken cancellationToken = default)
    {
        var json = JsonConvert.SerializeObject(request);
        var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_httpClient.BaseAddress}GrapeSort/standards/{request.StandardId}", requestContent, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve standard");
    }
}