using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using wine_quality_mobile.Models.Requests.GrapeSorts;
using wine_quality_mobile.Services.GrapeSorts;

namespace wine_quality_mobile.Pages.GrapeSorts;

public partial class GrapeSortEdit
{
    [Parameter] public string GrapeSortId { get; set; }
    
    [Inject] private IGrapeSortsService GrapeSortsService { get; set; }
    
    private UpdateGrapeSortRequest UpdateGrapeSortRequest { get; set; }
    
    private bool _dataLoaded;
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            var grapeSort = await GrapeSortsService.GetGrapeSortByIdAsync(GrapeSortId);
            
            UpdateGrapeSortRequest = new UpdateGrapeSortRequest
            {
                Id = grapeSort.Id,
                Name = grapeSort.Name
            };
            
            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task UpdateGrapeSort(EditContext arg)
    {
        try
        {
            await GrapeSortsService.UpdateAsync(UpdateGrapeSortRequest);
            NavigationManager.NavigateTo($"/GrapeSorts/{GrapeSortId}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}