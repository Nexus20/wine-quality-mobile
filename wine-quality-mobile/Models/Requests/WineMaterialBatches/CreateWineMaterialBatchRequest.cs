using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.WineMaterialBatches;

public class CreateWineMaterialBatchRequest
{
    [Required] public string Name { get; set; } = null!;
    [Required] public DateTime HarvestDate { get; set; }
    [Required] public string HarvestLocation { get; set; } = null!;
    [Required] public string GrapeSortId { get; set; } = null!;
}