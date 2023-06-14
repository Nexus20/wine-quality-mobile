using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Requests.GrapeSorts.Standards;
using wine_quality_mobile.Models.Results.GrapeSorts.Standards;
using wine_quality_mobile.Services.GrapeSorts;

namespace wine_quality_mobile.Pages.GrapeSorts;

public partial class GrapeSortPhaseEditStandard
{
    [Parameter] public string GrapeSortId { get; set; }
    [Parameter] public string StandardId { get; set; }

    [Inject] private IGrapeSortsService GrapeSortService { get; set; }
    
    private GrapeSortProcessPhaseParameterStandardResult Standard { get; set; }
    private bool StandardLoaded { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            Standard = await GrapeSortService.GetStandardByIdAsync(StandardId);
            StandardLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    private async Task SaveAsync()
    {
        var request = new UpdateGrapeSortProcessPhaseParameterStandardsRequestPart()
        {
            LowerBound = Standard.LowerBound.Value,
            UpperBound = Standard.UpperBound.Value,
            StandardId = Standard.Id,
        };
        
        await GrapeSortService.UpdateStandardAsync(request);
        NavigationManager.NavigateTo($"/GrapeSorts/{GrapeSortId}");
    }
}