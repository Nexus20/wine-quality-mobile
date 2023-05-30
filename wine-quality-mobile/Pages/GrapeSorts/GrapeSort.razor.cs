using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.GrapeSorts;
using wine_quality_mobile.Services.GrapeSorts;

namespace wine_quality_mobile.Pages.GrapeSorts;

public partial class GrapeSort
{
    [Parameter] public string GrapeSortId { get; set; }
    [Inject] private IGrapeSortsService GrapeSortService { get; set; }

    private GrapeSortDetailsResult GrapeSortDetails { get; set; }
    private bool GrapeSortDetailsLoaded { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            GrapeSortDetails = await GrapeSortService.GetGrapeSortByIdAsync(GrapeSortId);
            GrapeSortDetailsLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }
}