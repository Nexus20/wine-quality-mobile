using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.GrapeSorts;
using wine_quality_mobile.Services.GrapeSorts;

namespace wine_quality_mobile.Pages.GrapeSorts;

public partial class GrapeSorts
{
    [Inject] private IGrapeSortsService GrapeSortService { get; set; } = null!;

    private List<GrapeSortResult> grapeSorts { get; set; } = new();
    private bool grapeSortsLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            grapeSorts = await GrapeSortService.GetGrapeSortsAsync();
            grapeSortsLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}