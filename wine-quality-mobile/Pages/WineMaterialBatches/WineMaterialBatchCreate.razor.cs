using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Requests.WineMaterialBatches;
using wine_quality_mobile.Models.Results.GrapeSorts;
using wine_quality_mobile.Services.GrapeSorts;
using wine_quality_mobile.Services.WineMaterialBatches;

namespace wine_quality_mobile.Pages.WineMaterialBatches;

public partial class WineMaterialBatchCreate
{
    [Parameter] public string GrapeSortId { get; set; } = null!;
    
    [Inject] private IWineMaterialBatchService WineMaterialBatchService { get; set; } = null!;
    [Inject] private IGrapeSortsService GrapeSortsService { get; set; } = null!;
    
    private GrapeSortDetailsResult GrapeSort { get; set; } = null!;
    private CreateWineMaterialBatchRequest Request { get; set; } = new();
    
    private bool _dataLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            GrapeSort = await GrapeSortsService.GetGrapeSortByIdAsync(GrapeSortId);
            Request.GrapeSortId = GrapeSortId;
            Request.HarvestDate = DateTime.Now;
            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }

    private async Task CreateWineMaterialBatchAsync()
    {
        try
        {
            await WineMaterialBatchService.CreateAsync(Request);
            NavigationManager.NavigateTo($"/GrapeSorts/{GrapeSortId}/WineMaterialBatches");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}