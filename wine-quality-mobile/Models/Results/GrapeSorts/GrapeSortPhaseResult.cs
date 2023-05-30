using wine_quality_mobile.Models.Results.Abstract;
using wine_quality_mobile.Models.Results.GrapeSorts.Standards;
using wine_quality_mobile.Models.Results.ProcessParameters;

namespace wine_quality_mobile.Models.Results.GrapeSorts;

public class GrapeSortPhaseResult : BaseResult
{
    public string PhaseId { get; set; } = null!;
    public string PhaseName { get; set; } = null!;

    public List<GrapeSortProcessPhaseParameterStandardResult> GrapeSortProcessPhaseParameterStandards { get; set; }

    public int Duration { get; set; }
    public int Order { get; set; }
    public List<ProcessParameterResult> Parameters { get; set; }
}