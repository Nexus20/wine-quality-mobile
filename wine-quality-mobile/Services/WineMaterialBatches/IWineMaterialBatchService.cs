using wine_quality_mobile.Models.Requests.WineMaterialBatches;
using wine_quality_mobile.Models.Results.WineMaterialBatches;

namespace wine_quality_mobile.Services.WineMaterialBatches;

public interface IWineMaterialBatchService
{
    Task<List<WineMaterialBatchResult>> GetAsync(GetWineMaterialBatchesRequest request, CancellationToken cancellationToken = default);
    Task<WineMaterialBatchDetailsResult> GetDetailsByIdAsync(string id, CancellationToken cancellationToken = default);

    Task<WineMaterialBatchGrapeSortPhaseDetailsResult> GetPhaseDetailsByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<WineMaterialBatchPhaseParameterChartDataResult> GetChartDataForPhaseParameterAsync(GetWineMaterialBatchPhaseParameterChartDataRequest requestBody, CancellationToken cancellationToken = default);
    Task CreateAsync(CreateWineMaterialBatchRequest request, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateWineMaterialBatchRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}