using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using wine_quality_mobile.Models.Requests.ProcessPhases;
using wine_quality_mobile.Models.Results.ProcessPhases;
using wine_quality_mobile.Services.Phases;

namespace wine_quality_mobile.Pages.Phases;

public partial class PhaseEdit
{
    [Parameter]
    public string PhaseId { get; set; }
    
    public ProcessPhaseResult Phase { get; set; }
    
    [Inject]
    private IPhasesService PhasesService { get; set; }
    
    private UpdateProcessPhaseRequest UpdateProcessPhaseRequest { get; set; }
    
    private bool _phaseLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Phase = await PhasesService.GetPhaseByIdAsync(PhaseId);
            
            UpdateProcessPhaseRequest = new UpdateProcessPhaseRequest
            {
                Id = PhaseId,
                Name = Phase.Name
            };
            _phaseLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }

    private async Task EditPhase(EditContext arg)
    {
        try
        {
            await PhasesService.UpdateProcessPhaseAsync(UpdateProcessPhaseRequest);
            NavigationManager.NavigateTo("/Phases");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}