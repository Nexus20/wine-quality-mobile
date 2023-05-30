using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.GrapeSorts;

public class TrainPhaseModelRequest
{
    [Required]
    public string DatasetId { get; set; } = null!;
}