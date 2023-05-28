using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Results.ProcessPhases;
using wine_quality_mobile.Services.Phases;

namespace wine_quality_mobile.Pages.Phases;

public partial class Phases
{
    [Inject] private IPhasesService PhaseService { get; set; } = null!;

    private List<ProcessPhaseResult> phases { get; set; } = new();
    private bool phasesLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            phases = await PhaseService.GetPhasesAsync();
            phasesLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}