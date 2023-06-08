using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Requests.WineMaterialBatches;
using wine_quality_mobile.Models.Results.WineMaterialBatches;
using wine_quality_mobile.Services.WineMaterialBatches;

namespace wine_quality_mobile.Pages.GrapeSorts;

public partial class GrapeSortWineMaterialBatches
{
    [Parameter] public string GrapeSortId { get; set; }
    
    [Inject] private IWineMaterialBatchService WineMaterialBatchService { get; set; }

    private List<WineMaterialBatchResult> WineMaterialBatches { get; set; }
    
    private bool WineMaterialBatchesLoaded { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            WineMaterialBatches = await WineMaterialBatchService.GetAsync(new GetWineMaterialBatchesRequest()
            {
                GrapeSortId = GrapeSortId
            });
            WineMaterialBatchesLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }
}