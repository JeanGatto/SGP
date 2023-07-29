using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SGP.PublicApi.HealthChecks;

namespace SGP.PublicApi.Extensions;

[ExcludeFromCodeCoverage]
public static class HealthCheckBuilderExtensions
{
    public static IHealthChecksBuilder AddGCInfoCheck(this IHealthChecksBuilder builder) =>
        builder.AddCheck<GCInfoHealthCheck>("GCInfo", HealthStatus.Degraded, tags: new[] { "memory" });
}