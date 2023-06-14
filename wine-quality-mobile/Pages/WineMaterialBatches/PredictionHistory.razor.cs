using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.GrapeSorts;
using wine_quality_mobile.Services.QualityPrediction;

namespace wine_quality_mobile.Pages.WineMaterialBatches;

public partial class PredictionHistory
{
    [Parameter] public string WineMaterialBatchId { get; set; } = null!;
    [Parameter] public string WineMaterialBatchGrapeSortPhaseId { get; set; } = null!;
    
    [Inject] private IQualityPredictionService QualityPredictionService { get; set; } = null!;
    
    private List<PredictionDetailsResult> _predictionHistory = new();
    
    private bool _dataLoaded;
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            _predictionHistory = await QualityPredictionService.GetPredictionHistoryAsync(WineMaterialBatchGrapeSortPhaseId);
            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }
}