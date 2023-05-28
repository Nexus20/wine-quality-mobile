using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.ProcessPhases;
using wine_quality_mobile.Services.Phases;

namespace wine_quality_mobile.Pages.Phases;

public partial class Phase
{
    [Parameter] public string PhaseId { get; set; } = null!;

    [Inject] private IPhasesService PhasesService { get; set; } = null!;

    private ProcessPhaseDetailResult _phase;
    private bool _phaseLoaded = false;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _phase = await PhasesService.GetPhaseByIdAsync(PhaseId);
            _phaseLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        await base.OnInitializedAsync();
    }
}