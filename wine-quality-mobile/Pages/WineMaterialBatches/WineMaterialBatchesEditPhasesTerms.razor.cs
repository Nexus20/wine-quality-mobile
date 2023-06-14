using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Requests.WineMaterialBatches;
using wine_quality_mobile.Models.Results.WineMaterialBatches;
using wine_quality_mobile.Services.WineMaterialBatches;

namespace wine_quality_mobile.Pages.WineMaterialBatches;

public partial class WineMaterialBatchesEditPhasesTerms
{
    [Parameter] public string WineMaterialBatchId { get; set; }
    [Inject] private IWineMaterialBatchService WineMaterialBatchesService { get; set; }
    
    private WineMaterialBatchDetailsResult _wineMaterialBatch;
    private bool _dataLoaded;
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            _wineMaterialBatch = await WineMaterialBatchesService.GetDetailsByIdAsync(WineMaterialBatchId);
            _wineMaterialBatch.Phases.ForEach(x =>
            {
                if(x.StartDate == DateTime.MinValue)
                    x.StartDate = DateTime.Now;
                
                if(x.EndDate == DateTime.MinValue)
                    x.EndDate = DateTime.Now;
            });
            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    private async Task SaveAsync() {

        try
        {
            var request = new UpdateWineMaterialBatchPhasesTermsRequest()
            {
                Terms = _wineMaterialBatch.Phases.Select(p => new UpdateWineMaterialBatchPhasesTerm()
                {
                    Id = p.Id,
                    EndDate = p.EndDate,
                    StartDate = p.StartDate
                }).ToList()
            };
            
            await WineMaterialBatchesService.UpdatePhasesTermsAsync(request);
            NavigationManager.NavigateTo($"/WineMaterialBatches/{WineMaterialBatchId}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}