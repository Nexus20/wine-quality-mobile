using wine_quality_mobile.Models.Results.Abstract;
using wine_quality_mobile.Models.Results.GrapeSorts;

namespace wine_quality_mobile.Models.Results.WineMaterialBatches;

public class WineMaterialBatchDetailsResult : BaseResult
{
    public string Name { get; set; } = null!;
    public DateTime HarvestDate { get; set; }
    public string HarvestLocation { get; set; } = null!;
    public GrapeSortResult GrapeSort { get; set; } = null!;
    public List<WineMaterialBatchGrapeSortPhaseResult> Phases { get; set; } = null!;
    public ActiveWineMaterialBatchGrapeSortPhaseResult ActivePhase { get; set; }
}