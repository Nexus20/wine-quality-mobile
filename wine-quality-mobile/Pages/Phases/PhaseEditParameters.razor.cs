using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Requests.ProcessPhases;
using wine_quality_mobile.Models.Results.ProcessParameters;
using wine_quality_mobile.Models.Results.ProcessPhases;
using wine_quality_mobile.Services.Parameters;
using wine_quality_mobile.Services.Phases;

namespace wine_quality_mobile.Pages.Phases;

public partial class PhaseEditParameters
{
    [Parameter] public string PhaseId { get; set; }

    [Inject] private IPhasesService PhasesService { get; set; }

    [Inject] private IParametersService ParametersService { get; set; }

    private ProcessPhaseDetailResult Phase { get; set; }
    private List<ProcessParameterResult> Parameters { get; set; }
    private List<string> InitialPhaseParametersIds { get; set; }

    private readonly List<string> _parametersIdsToAdd = new();
    private readonly List<string> _parametersIdsToRemove = new();

    private bool _dataLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var phaseTask = PhasesService.GetPhaseByIdAsync(PhaseId);
            var parametersTask = ParametersService.GetParametersAsync();

            await Task.WhenAll(phaseTask, parametersTask);

            Phase = phaseTask.Result;

            var phaseParametersIds = Phase.Parameters.Select(p => p.Id).ToList();

            Parameters = parametersTask.Result.Where(x => !phaseParametersIds.Contains(x.Id)).ToList();
            
            InitialPhaseParametersIds = Phase.Parameters.Select(x => x.Id).ToList();
            
            _dataLoaded = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        await base.OnInitializedAsync();
    }

    private async Task AddParameter(ProcessParameterResult parameter)
    {
        Phase.Parameters.Add(parameter);
        Parameters.Remove(parameter);
        
        if(!InitialPhaseParametersIds.Contains(parameter.Id))
            _parametersIdsToAdd.Add(parameter.Id);
        
        _parametersIdsToRemove.Remove(parameter.Id);
        
        await InvokeAsync(StateHasChanged);
    }

    private async Task RemoveParameter(ProcessParameterResult parameter)
    {
        Phase.Parameters.Remove(parameter);
        Parameters.Add(parameter);
        _parametersIdsToAdd.Remove(parameter.Id);
        
        if(InitialPhaseParametersIds.Contains(parameter.Id))
            _parametersIdsToRemove.Add(parameter.Id);
        
        await InvokeAsync(StateHasChanged);
    }

    private async Task SaveParameters()
    {
        if(_parametersIdsToAdd.Count == 0 && _parametersIdsToRemove.Count == 0)
            return;
        
        try
        {
            var request = new EditPhaseParametersRequest
            {
                ProcessPhaseId = PhaseId,
                ProcessParametersIdsToAdd = _parametersIdsToAdd.ToArray(),
                ProcessParametersIdsToRemove = _parametersIdsToRemove.ToArray()
            };

            await PhasesService.EditPhaseParametersAsync(request);

            NavigationManager.NavigateTo($"/Phases/{PhaseId}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}