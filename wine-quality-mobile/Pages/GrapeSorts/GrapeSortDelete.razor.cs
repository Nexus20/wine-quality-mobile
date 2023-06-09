using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.GrapeSorts;
using wine_quality_mobile.Services.GrapeSorts;

namespace wine_quality_mobile.Pages.GrapeSorts;

public partial class GrapeSortDelete
{
    [Parameter] public string GrapeSortId { get; set; }
    
    [Inject] private IGrapeSortsService GrapeSortsService { get; set; }
    
    private GrapeSortDetailsResult GrapeSort { get; set; }
    
    private bool _dataLoaded;
    
    protected override async Task<Task> OnInitializedAsync()
    {
        try
        {
            GrapeSort = await GrapeSortsService.GetGrapeSortByIdAsync(GrapeSortId);
            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return base.OnInitializedAsync();
    }

    private async Task DeleteGrapeSort()
    {
        try
        {
            await GrapeSortsService.DeleteAsync(GrapeSortId);
            NavigationManager.NavigateTo("/GrapeSorts");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}