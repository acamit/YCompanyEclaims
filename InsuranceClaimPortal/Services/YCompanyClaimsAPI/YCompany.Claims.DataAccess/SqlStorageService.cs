using YCompany.Claims.Domain.InfrastructureInterfaces;

namespace YCompany.Claims.DataAccess
{
    public class SqlStorageService : IClaimsStorageService
    {
        public Task<bool> CheckHealthAsync()
        {
            return Task.FromResult(true);
        }
    }
}
