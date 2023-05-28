using wine_quality_mobile.Models.Results.ProcessParameters;

namespace wine_quality_mobile.Models.Results.ProcessPhases;

public class ProcessPhaseDetailResult : ProcessPhaseResult
{
    public List<ProcessParameterResult> Parameters { get; set; }
}