using wine_quality_mobile.Models.Results.Abstract;

namespace wine_quality_mobile.Models.Results.GrapeSorts.Standards;

public class GrapeSortProcessPhaseParameterStandardResult : BaseResult
{
    public double? LowerBound { get; set; }
    public double? UpperBound { get; set; }

    public string GrapeSortName { get; set; } = null!;
    public string PhaseName { get; set; } = null!;
    public string ParameterName { get; set; } = null!;
}