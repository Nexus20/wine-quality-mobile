using System.Text;
using Newtonsoft.Json;
using wine_quality_mobile.Models.Requests.GrapeSorts;
using wine_quality_mobile.Models.Results.GrapeSorts;

namespace wine_quality_mobile.Services.QualityPrediction;

public class QualityPredictionService : IQualityPredictionService
{
    private readonly HttpClient _httpClient;

    public QualityPredictionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<GrapeSortPhaseForecastModelResult>> GetModelsAsync(string grapeSortPhaseId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/{grapeSortPhaseId}/models", cancellationToken);
        
        if(!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve models");

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        
        if(string.IsNullOrWhiteSpace(json))
            return new List<GrapeSortPhaseForecastModelResult>();
        
        var result = JsonConvert.DeserializeObject<List<GrapeSortPhaseForecastModelResult>>(json);
        return result;
    }

    public async Task<PredictionDetailsResult> PredictAsync(PredictQualityRequest request, CancellationToken cancellationToken = default)
    {
        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}/predict", content, cancellationToken);
        
        if(!response.IsSuccessStatusCode)
            throw new Exception("Unable to predict quality");
        
        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<PredictionDetailsResult>(responseJson);
        return result;
    }

    public async Task<PredictionDetailsResult> GetPredictionDetailsAsync(string predictionId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/predictions/{predictionId}", cancellationToken);
        
        if(!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve prediction details");
        
        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<PredictionDetailsResult>(responseJson);
        return result;
    }

    public async Task<List<PredictionDetailsResult>> GetPredictionHistoryAsync(string wineMaterialBatchGrapeSortPhaseId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/{wineMaterialBatchGrapeSortPhaseId}/history", cancellationToken);
        
        if(!response.IsSuccessStatusCode)
            throw new Exception("Unable to retrieve prediction history");
        
        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<List<PredictionDetailsResult>>(responseJson);
        return result;
    }
}