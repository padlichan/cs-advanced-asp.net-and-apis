using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using cs_advanced_asp.net_and_apis.Models;

namespace cs_advanced_asp.net_and_apis.HealthChecks;

public class TeachersHealthCheck : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        string path = "Resources/Teachers.json";
        if (!File.Exists(path)) return HealthCheckResult.Unhealthy("Missing file.");
        string jsonData = await File.ReadAllTextAsync(path, cancellationToken);


        var data = JsonSerializer.Deserialize<List<Teacher>>(jsonData);

        if (data?.Count > 0) return HealthCheckResult.Healthy("There are available teachers");
        return HealthCheckResult.Unhealthy("There are no available teachers");
    }
}
