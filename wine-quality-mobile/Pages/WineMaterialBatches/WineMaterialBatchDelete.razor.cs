using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.WineMaterialBatches;
using wine_quality_mobile.Services.WineMaterialBatches;

namespace wine_quality_mobile.Pages.WineMaterialBatches;

public partial class WineMaterialBatchDelete
{
    [Parameter] public string WineMaterialBatchId { get; set; } = null!;

    private WineMaterialBatchDetailsResult WineMaterialBatch { get; set; }
    private bool _dataLoaded;
    
    [Inject]
    private IWineMaterialBatchService WineMaterialBatchService { get; set; }

    protected override async Task<Task> OnInitializedAsync()
    {
        try
        {
            WineMaterialBatch = await WineMaterialBatchService.GetDetailsByIdAsync(WineMaterialBatchId);
            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return base.OnInitializedAsync();
    }

    private async Task DeleteWineMaterialBatchAsync()
    {
        try
        {
            await WineMaterialBatchService.DeleteAsync(WineMaterialBatchId);
            NavigationManager.NavigateTo($"/GrapeSorts/{WineMaterialBatch.GrapeSort.Id}/WineMaterialBatches");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}