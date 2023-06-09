﻿using System.ComponentModel.DataAnnotations;

namespace wine_quality_mobile.Models.Requests.GrapeSorts;

public class SaveGrapeSortPhasesOrderRequest
{
    [Required] public string GrapeSortId { get; set; } = null!;
    [Required] public List<SaveGrapeSortPhasesOrderRequestPart> Phases { get; set; } = null!;
}

public class SaveGrapeSortPhasesOrderRequestPart
{
    [Required] public string PhaseId { get; set; } = null!;
    [Required] public int Order { get; set; }
}