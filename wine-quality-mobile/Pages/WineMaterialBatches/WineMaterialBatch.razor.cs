using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.WineMaterialBatches;
using wine_quality_mobile.Services.WineMaterialBatches;

namespace wine_quality_mobile.Pages.WineMaterialBatches;

public partial class WineMaterialBatch
{
    [Parameter] public string WineMaterialBatchId { get; set; }
    
    [Inject] private IWineMaterialBatchService WineMaterialBatchService { get; set; }
    
    private WineMaterialBatchDetailsResult WineMaterialBatchDetails { get; set; }
    
    private bool WineMaterialBatchDetailsLoaded { get; set; }
    private bool _activePhaseVisible = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            WineMaterialBatchDetails = await WineMaterialBatchService.GetDetailsByIdAsync(WineMaterialBatchId);
            WineMaterialBatchDetailsLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }
    
    private void ToggleActivePhaseVisibility()
    {
        _activePhaseVisible = !_activePhaseVisible;
    }
}