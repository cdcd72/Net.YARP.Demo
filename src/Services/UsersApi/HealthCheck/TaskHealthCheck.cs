using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace UsersApi.HealthCheck;

public class TaskHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        // Implement Health Check logic to determine health status.
        var isHealthy = true;

        return Task.FromResult(isHealthy ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy());
    }
}