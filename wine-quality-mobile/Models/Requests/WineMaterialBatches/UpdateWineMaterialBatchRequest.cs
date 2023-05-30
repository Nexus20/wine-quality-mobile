using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.WineMaterialBatches;

public class UpdateWineMaterialBatchRequest
{
    [Required] public string Id { get; set; } = null!;
    [Required] public string Name { get; set; } = null!;
    [Required] public DateTime HarvestDate { get; set; }
    [Required] public string HarvestLocation { get; set; } = null!;
}