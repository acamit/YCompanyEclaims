using YCompany.Reporting.Domain.InfrastructureInterfaces;

namespace YCompany.Reporting.DataAccess
{
    public class SqlStorageService : IReportingStorageService
    {
        public Task<bool> CheckHealthAsync()
        {
            return Task.FromResult(true);
        }
    }
}
