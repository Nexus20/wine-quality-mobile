using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using wine_quality_mobile.Models.Requests.GrapeSorts;
using wine_quality_mobile.Services.GrapeSorts;

namespace wine_quality_mobile.Pages.GrapeSorts;

public partial class GrapeSortCreate
{
    [Inject] private IGrapeSortsService GrapeSortsService { get; set; }
    
    private CreateGrapeSortRequest CreateGrapeSortRequest { get; set; } = new();
    
    private async Task CreateGrapeSort(EditContext arg)
    {
        try
        {
            await GrapeSortsService.CreateAsync(CreateGrapeSortRequest);
            NavigationManager.NavigateTo("/GrapeSorts");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}