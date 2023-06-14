using wine_quality_mobile.Models.Requests.GrapeSorts;
using wine_quality_mobile.Models.Results.GrapeSorts;

namespace wine_quality_mobile.Services.QualityPrediction;

public interface IQualityPredictionService
{
    Task<List<GrapeSortPhaseForecastModelResult>> GetModelsAsync(string grapeSortPhaseId, CancellationToken cancellationToken = default);
    Task<PredictionDetailsResult> PredictAsync(PredictQualityRequest request, CancellationToken cancellationToken = default);
    Task<PredictionDetailsResult> GetPredictionDetailsAsync(string predictionId, CancellationToken cancellationToken = default);
    Task<List<PredictionDetailsResult>> GetPredictionHistoryAsync(string wineMaterialBatchGrapeSortPhaseId, CancellationToken cancellationToken = default);
}