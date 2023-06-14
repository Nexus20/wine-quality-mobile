using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Requests.GrapeSorts;
using wine_quality_mobile.Models.Results.GrapeSorts;
using wine_quality_mobile.Models.Results.WineMaterialBatches;
using wine_quality_mobile.Services.QualityPrediction;
using wine_quality_mobile.Services.WineMaterialBatches;

namespace wine_quality_mobile.Pages.WineMaterialBatches;

public partial class MakePrediction
{
    [Parameter] public string WineMaterialBatchId { get; set; } = null!;
    [Parameter] public string WineMaterialBatchGrapeSortPhaseId { get; set; } = null!;
    [Inject] private IQualityPredictionService QualityPredictionService { get; set; } = null!;
    [Inject] private IWineMaterialBatchService WineMaterialBatchService { get; set; } = null!;
    
    private List<GrapeSortPhaseForecastModelResult> _models = new();
    private WineMaterialBatchGrapeSortPhaseDetailsResult _wineMaterialBatchGrapeSortPhaseDetailsResult = null!;
    
    private readonly PredictQualityRequest _predictQualityRequest = new();
        
    private bool _dataLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _wineMaterialBatchGrapeSortPhaseDetailsResult = await WineMaterialBatchService.GetPhaseDetailsByIdAsync(WineMaterialBatchGrapeSortPhaseId);
            _models = await QualityPredictionService.GetModelsAsync(_wineMaterialBatchGrapeSortPhaseDetailsResult.Phase.Id);
            _dataLoaded = true;
            
            _predictQualityRequest.WineMaterialBatchGrapeSortPhaseId = WineMaterialBatchGrapeSortPhaseId;
            _predictQualityRequest.ForecastModelId = _models.First().Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }

    private void ModelSelected(ChangeEventArgs arg)
    {
        try
        {
            _predictQualityRequest.ForecastModelId = arg.Value!.ToString()!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    private async Task PredictAsync()
    {
        try
        {
            var result = await QualityPredictionService.PredictAsync(_predictQualityRequest);
            NavigationManager.NavigateTo($"/WineMaterialBatches/{WineMaterialBatchId}/Phases/{WineMaterialBatchGrapeSortPhaseId}/Predictions/{result.Id}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}