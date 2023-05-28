using wine_quality_mobile.Models.Results.ProcessPhases;

namespace wine_quality_mobile.Models.Results.ProcessParameters;

public class ProcessParameterDetailsResult : ProcessParameterResult
{
    public virtual List<ProcessPhaseResult> Phases { get; set; }
}