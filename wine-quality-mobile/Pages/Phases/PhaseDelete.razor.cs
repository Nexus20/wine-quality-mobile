using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.ProcessPhases;
using wine_quality_mobile.Services.Phases;

namespace wine_quality_mobile.Pages.Phases;

public partial class PhaseDelete
{
    [Parameter]
    public string PhaseId { get; set; }
    
    private ProcessPhaseResult Phase { get; set; }
    private bool _phaseLoaded;
    
    [Inject]
    private IPhasesService PhasesService { get; set; }

    protected override async Task<Task> OnInitializedAsync()
    {
        try
        {
            Phase = await PhasesService.GetPhaseByIdAsync(PhaseId);
            _phaseLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return base.OnInitializedAsync();
    }

    private async Task DeletePhase()
    {
        try
        {
            await PhasesService.DeleteProcessPhaseAsync(PhaseId);
            NavigationManager.NavigateTo("/Phases");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}