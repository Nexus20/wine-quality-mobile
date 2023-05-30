using wine_quality_mobile.Models.Results.Abstract;
using wine_quality_mobile.Models.Results.WineMaterialBatches;

namespace wine_quality_mobile.Models.Results.GrapeSorts;

public class GrapeSortDetailsResult : BaseResult
{
    public string Name { get; set; } = null!;
    public List<GrapeSortPhaseResult> Phases { get; set; }
    public List<WineMaterialBatchResult> WineMaterialBatches { get; set; }
}