using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.WineMaterialBatches;

public class ChangeWineProcessingRequestRunningState
{
    [Required] public string WineMaterialBatchId { get; set; } = null!;
    [Required] public string WineMaterialBatchGrapeSortPhaseId { get; set; } = null!;
}