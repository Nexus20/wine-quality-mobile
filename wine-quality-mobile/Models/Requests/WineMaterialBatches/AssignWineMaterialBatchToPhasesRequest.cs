using System.ComponentModel.DataAnnotations;
using wine_quality_mobile.Enums;

namespace wine_quality_mobile.Models.Requests.WineMaterialBatches;

public class AssignWineMaterialBatchToPhasesRequest
{
    [Required] public string WineMaterialBatchId { get; set; } = null!;

    [Required] public List<AssignWineMaterialBatchToPhasesRequestPart> Phases { get; set; } = null!;
    
    public class AssignWineMaterialBatchToPhasesRequestPart
    {
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
        [Required] public string GrapeSortPhaseId { get; set; } = null!;
    }
}

public class UpdateWineMaterialBatchPhasesTermsRequest
{
    [Required] public List<UpdateWineMaterialBatchPhasesTerm> Terms { get; set; } = null!;
}

public class UpdateWineMaterialBatchPhasesTerm
{
    [Required] public string Id { get; set; } = null!;
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }
}

public class GetWineMaterialBatchPhaseParameterChartDataRequest
{
    [Required] public string WineMaterialBatchGrapeSortPhaseParameterId { get; set; } = null!;
    [Required] public ParameterChartType ChartType { get; set; }
}