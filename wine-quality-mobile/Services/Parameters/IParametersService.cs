using wine_quality_mobile.Models.Results.ProcessParameters;

namespace wine_quality_mobile.Services.Parameters;

public interface IParametersService
{
    Task<List<ProcessParameterResult>> GetParametersAsync(CancellationToken cancellationToken = default);
    Task<ProcessParameterDetailResult> GetParameterByIdAsync(string parameterId, CancellationToken cancellationToken = default);
}