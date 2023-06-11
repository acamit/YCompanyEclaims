using Microsoft.Extensions.Diagnostics.HealthChecks;
using YCompany.HealthChecks.Interfaces;

namespace YCompany.HealthChecks
{
    public class StorageHealthChecks : IHealthCheck
    {
        private readonly IStorageHealth _storageService;

        public StorageHealthChecks(IStorageHealth storageService)
        {
            _storageService = storageService;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isStorageOk = await _storageService.CheckHealthAsync();
            return isStorageOk ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
        }
    }
}
