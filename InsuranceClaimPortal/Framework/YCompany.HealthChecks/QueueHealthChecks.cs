using Microsoft.Extensions.Diagnostics.HealthChecks;
using YCompany.Claims.MessagingQueue;

namespace YCompany.HealthChecks
{
    public class QueueHealthChecks : IHealthCheck
    {
        private readonly IMessageBroker _messageBroker;

        public QueueHealthChecks(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isMessageBrokerOk = await _messageBroker.CheckHealthAsync();
            return isMessageBrokerOk ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
        }
    }
}
