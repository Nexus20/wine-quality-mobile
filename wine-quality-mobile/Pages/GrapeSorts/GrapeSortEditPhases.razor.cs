using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Requests.GrapeSorts;
using wine_quality_mobile.Models.Results.ProcessPhases;
using wine_quality_mobile.Services.GrapeSorts;
using wine_quality_mobile.Services.Phases;

namespace wine_quality_mobile.Pages.GrapeSorts;

public partial class GrapeSortEditPhases
{
    [Parameter] public string GrapeSortId { get; set; }

    [Inject] private IGrapeSortsService GrapeSortsService { get; set; }
    [Inject] private IPhasesService PhasesService { get; set; }

    private List<string> _initialGrapeSortPhasesIds;
    private List<ProcessPhaseResult> _availablePhases;
    private List<ProcessPhaseResult> _grapeSortPhases;

    private bool _dataLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var phasesTask = PhasesService.GetPhasesAsync();
            var grapeSortPhasesTask = GrapeSortsService.GetPhasesAsync(GrapeSortId);

            await Task.WhenAll(phasesTask, grapeSortPhasesTask);

            _grapeSortPhases = grapeSortPhasesTask.Result.Select(x => new ProcessPhaseResult()
                {
                    Id = x.PhaseId,
                    Name = x.PhaseName
                })
                .ToList();

            var grapeSortPhasesIds = _grapeSortPhases.Select(x => x.Id).ToList();
            _availablePhases = phasesTask.Result.Where(x => !grapeSortPhasesIds.Contains(x.Id)).ToList();
            _initialGrapeSortPhasesIds = _grapeSortPhases.Select(x => x.Id).ToList();

            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private void MoveToAssigned(ProcessPhaseResult phase)
    {
        if (_grapeSortPhases.Contains(phase))
            return;
        
        _availablePhases.Remove(phase);
        _grapeSortPhases.Add(phase);
    }

    private void MoveToAvailable(ProcessPhaseResult phase)
    {
        if (_availablePhases.Contains(phase))
            return;
        
        _grapeSortPhases.Remove(phase);
        _availablePhases.Add(phase);
    }

    private void MoveUp(int index)
    {
        var phase = _grapeSortPhases[index];
        _grapeSortPhases.RemoveAt(index);
        _grapeSortPhases.Insert(index - 1, phase);
    }

    private void MoveDown(int index)
    {
        var phase = _grapeSortPhases[index];
        _grapeSortPhases.RemoveAt(index);
        _grapeSortPhases.Insert(index + 1, phase);
    }

    private async Task SavePhasesOrderAsync()
    {
        try
        {
            var requestBody = new SaveGrapeSortPhasesOrderRequest()
            {
                GrapeSortId = GrapeSortId,
                Phases = _grapeSortPhases.Select((x, i) => new SaveGrapeSortPhasesOrderRequestPart()
                {
                    PhaseId = x.Id,
                    Order = i
                }).ToList()
            };

            await GrapeSortsService.SavePhasesOrderAsync(requestBody);
            
            NavigationManager.NavigateTo($"/GrapeSorts/{GrapeSortId}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}