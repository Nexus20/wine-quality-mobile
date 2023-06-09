using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using wine_quality_mobile.Models.Requests.ProcessPhases;
using wine_quality_mobile.Services.Phases;

namespace wine_quality_mobile.Pages.Phases;

public partial class PhaseCreate
{
    [Inject] private IPhasesService PhasesService { get; set; }
    
    private CreateProcessPhaseRequest CreateProcessPhaseRequest { get; set; } = new();

    private async Task CreatePhase(EditContext arg)
    {
        try
        {
            await PhasesService.CreatePhaseAsync(CreateProcessPhaseRequest);
            NavigationManager.NavigateTo("/Phases");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}