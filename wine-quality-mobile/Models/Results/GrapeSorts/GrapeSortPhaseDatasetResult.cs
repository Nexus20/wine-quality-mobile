using wine_quality_mobile.Models.Dtos.Files;
using wine_quality_mobile.Models.Results.Abstract;

namespace wine_quality_mobile.Models.Results.GrapeSorts;

public class GrapeSortPhaseDatasetResult : BaseResult
{
    public FileNameWithUrlDto DatasetInfo { get; set; } = null!;
}