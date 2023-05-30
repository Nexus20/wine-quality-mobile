using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Models.Requests.GrapeSorts.Standards;
using wine_quality_mobile.Models.Results.GrapeSorts;
using wine_quality_mobile.Models.Results.ProcessParameters;
using wine_quality_mobile.Services.GrapeSorts;

namespace wine_quality_mobile.Pages.GrapeSorts;

public partial class GrapeSortPhaseCreateStandard
{
    [Parameter] public string GrapeSortId { get; set; }
    [Parameter] public string GrapeSortPhaseId { get; set; }
    [Inject] private IGrapeSortsService GrapeSortService { get; set; }

    private GrapeSortDetailsResult GrapeSortDetails { get; set; }
    private GrapeSortPhaseResult GrapeSortPhase { get; set; }
    private List<ProcessParameterResult> AvailableParameters { get; set; }
    private bool GrapeSortDetailsLoaded { get; set; }
    
    private ProcessParameterResult selectedParameter;
    private double lowerBound;
    private double upperBound;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            GrapeSortDetails = await GrapeSortService.GetGrapeSortByIdAsync(GrapeSortId);
            GrapeSortDetailsLoaded = true;
            GrapeSortPhase = GrapeSortDetails.Phases.Single(x => x.Id == GrapeSortPhaseId);
            AvailableParameters = GrapeSortPhase.Parameters
                .Where(x => GrapeSortPhase.GrapeSortProcessPhaseParameterStandards.All(s => s.ParameterName != x.Name))
                .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        await base.OnInitializedAsync();
    }

    private void SelectParameter(ChangeEventArgs e)
    {
        var selectedParameterId = e.Value.ToString();
        selectedParameter = AvailableParameters.Single(p => p.Id == selectedParameterId);
    }

    private async Task CreateStandard()
    {
        var request = new CreateGrapeSortProcessPhaseParameterStandardRequest
        {
            LowerBound = lowerBound,
            UpperBound = upperBound,
            GrapeSortPhaseId = GrapeSortPhaseId,
            ParameterId = selectedParameter.Id
        };
        
        await GrapeSortService.CreatePhaseParameterStandardAsync(request);
        NavigationManager.NavigateTo($"/GrapeSorts/{GrapeSortId}", true);
    }
}