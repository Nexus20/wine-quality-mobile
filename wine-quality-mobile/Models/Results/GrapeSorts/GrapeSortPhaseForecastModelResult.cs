using wine_quality_mobile.Models.Results.Abstract;

namespace wine_quality_mobile.Models.Results.GrapeSorts;

public class GrapeSortPhaseForecastModelResult : BaseResult
{
    public decimal? Accuracy { get; set; }
    public string ModelUri { get; set; }
    public string ModelName { get; set; }
    public GrapeSortPhaseDatasetResult DatasetInfo { get; set; } = null!;
}