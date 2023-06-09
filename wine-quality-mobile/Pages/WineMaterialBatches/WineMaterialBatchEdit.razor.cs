using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Requests.WineMaterialBatches;
using wine_quality_mobile.Models.Results.WineMaterialBatches;
using wine_quality_mobile.Services.WineMaterialBatches;

namespace wine_quality_mobile.Pages.WineMaterialBatches;

public partial class WineMaterialBatchEdit
{
    [Parameter] public string WineMaterialBatchId { get; set; } = null!;
    
    [Inject] private IWineMaterialBatchService WineMaterialBatchService { get; set; } = null!;
    
    private WineMaterialBatchDetailsResult WineMaterialBatch { get; set; }
    
    private UpdateWineMaterialBatchRequest Request { get; set; }
    
    private bool _dataLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            WineMaterialBatch = await WineMaterialBatchService.GetDetailsByIdAsync(WineMaterialBatchId);
            Request = new UpdateWineMaterialBatchRequest()
            {
                Id = WineMaterialBatchId,
                Name = WineMaterialBatch.Name,
                HarvestDate = WineMaterialBatch.HarvestDate,
                HarvestLocation = WineMaterialBatch.HarvestLocation
            };
            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }
    
    private async Task UpdateWineMaterialBatchAsync()
    {
        try
        {
            await WineMaterialBatchService.UpdateAsync(Request);
            NavigationManager.NavigateTo($"/WineMaterialBatches/{WineMaterialBatchId}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}