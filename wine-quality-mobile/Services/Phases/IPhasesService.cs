using wine_quality_mobile.Models.Requests.ProcessPhaseTypes;
using wine_quality_mobile.Models.Results.ProcessPhases;

namespace wine_quality_mobile.Services.Phases;

public interface IPhasesService
{
    Task<List<ProcessPhaseResult>> GetPhasesAsync(CancellationToken cancellationToken = default);
    Task<ProcessPhaseDetailResult> GetPhaseByIdAsync(string phaseId, CancellationToken cancellationToken = default);
    Task CreatePhaseAsync(CreateProcessPhaseRequest createProcessPhaseRequest, CancellationToken cancellationToken = default);
    Task UpdateProcessPhaseAsync(UpdateProcessPhaseRequest updateProcessPhaseRequest, CancellationToken cancellationToken = default);
    Task DeleteProcessPhaseAsync(string phaseId, CancellationToken cancellationToken = default);
}