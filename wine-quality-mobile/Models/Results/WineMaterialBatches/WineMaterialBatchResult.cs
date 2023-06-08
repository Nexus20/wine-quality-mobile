using wine_quality_mobile.Models.Results.Abstract;
using wine_quality_mobile.Models.Results.GrapeSorts;

namespace wine_quality_mobile.Models.Results.WineMaterialBatches;

public class WineMaterialBatchResult : BaseResult
{
    public string Name { get; set; }
    public DateTime HarvestDate { get; set; }
    public string HarvestLocation { get; set; }
    public List<WineMaterialBatchGrapeSortPhaseResult> Phases { get; set; } = null!;
    public GrapeSortResult GrapeSort { get; set; }
    public WineMaterialBatchGrapeSortPhaseResult ActivePhase => Phases.FirstOrDefault(x => x.IsActive);
}