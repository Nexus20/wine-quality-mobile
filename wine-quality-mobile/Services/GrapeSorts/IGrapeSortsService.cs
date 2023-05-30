﻿using wine_quality_mobile.Models.Requests.GrapeSorts.Standards;
using wine_quality_mobile.Models.Results.GrapeSorts;
using wine_quality_mobile.Models.Results.GrapeSorts.Standards;

namespace wine_quality_mobile.Services.GrapeSorts;

public interface IGrapeSortsService
{
    Task<List<GrapeSortResult>> GetGrapeSortsAsync(CancellationToken cancellationToken = default);
    Task<GrapeSortDetailsResult> GetGrapeSortByIdAsync(string grapeSortId, CancellationToken cancellationToken = default);
    Task CreatePhaseParameterStandardAsync(CreateGrapeSortProcessPhaseParameterStandardRequest request, CancellationToken cancellationToken = default);
    Task<GrapeSortProcessPhaseParameterStandardResult> GetStandardByIdAsync(string standardId, CancellationToken cancellationToken = default);
    Task UpdateStandardAsync(UpdateGrapeSortProcessPhaseParameterStandardsRequestPart request, CancellationToken cancellationToken = default);
}