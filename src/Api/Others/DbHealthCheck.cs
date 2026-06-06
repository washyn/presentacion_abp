using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Washyn.Kfc;
public class DbHealthCheck : IHealthCheck
{
   
    public DbHealthCheck()
    {
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            // can be test, db,s3, sqs, or another service that is required for consider as healthy
            return Task.FromResult(HealthCheckResult.Healthy());
        }
        catch (Exception ex)
        {
            return Task.FromResult(
                HealthCheckResult.Unhealthy(ex.Message));
        }
    }
}
