using wine_quality_mobile.Models.Results.ProcessPhases;

namespace wine_quality_mobile.Models.Results.ProcessParameters;

public class ProcessParameterDetailResult : ProcessParameterResult
{
    public List<ProcessPhaseResult> Phases { get; set; }
}