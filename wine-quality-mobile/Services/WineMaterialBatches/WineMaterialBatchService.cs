﻿using System.Text;
using Newtonsoft.Json;
using wine_quality_mobile.Models.Requests.WineMaterialBatches;
using wine_quality_mobile.Models.Results.WineMaterialBatches;

namespace wine_quality_mobile.Services.WineMaterialBatches;

public class WineMaterialBatchService : IWineMaterialBatchService
{
    private readonly HttpClient _httpClient;

    public WineMaterialBatchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<WineMaterialBatchResult>> GetAsync(GetWineMaterialBatchesRequest request, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{_httpClient.BaseAddress}";
        
        if(!string.IsNullOrWhiteSpace(request.GrapeSortId))
            requestUri += $"?GrapeSortId={request.GrapeSortId}";
            
        var response = await _httpClient.GetAsync(requestUri, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve sorts");

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<List<WineMaterialBatchResult>>(content);
        return result;
    }

    public async Task<WineMaterialBatchDetailsResult> GetDetailsByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{_httpClient.BaseAddress}/{id}/details";
        
        var response = await _httpClient.GetAsync(requestUri, cancellationToken);
        
        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve sorts");
        
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<WineMaterialBatchDetailsResult>(content);
        return result;
    }

    public async Task<WineMaterialBatchGrapeSortPhaseDetailsResult> GetPhaseDetailsByIdAsync(string id,
        CancellationToken cancellationToken = default)
    {
        var requestUri = $"{_httpClient.BaseAddress}/phases/{id}/details";
        
        var response = await _httpClient.GetAsync(requestUri, cancellationToken);
        
        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve wine material batch grape sort phase");
        
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<WineMaterialBatchGrapeSortPhaseDetailsResult>(content);
        return result;
    }

    public async Task<WineMaterialBatchPhaseParameterChartDataResult> GetChartDataForPhaseParameterAsync(GetWineMaterialBatchPhaseParameterChartDataRequest requestBody, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{_httpClient.BaseAddress}/phases/parameters/get_chart_data";
        
        requestUri += $"?WineMaterialBatchGrapeSortPhaseParameterId={requestBody.WineMaterialBatchGrapeSortPhaseParameterId}";
        requestUri += $"&ChartType={(int)requestBody.ChartType}";

        var response = await _httpClient.GetAsync(requestUri, cancellationToken);
        
        if (!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve wine material batch grape sort phase");
        
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<WineMaterialBatchPhaseParameterChartDataResult>(responseContent);
        return result;
    }
}