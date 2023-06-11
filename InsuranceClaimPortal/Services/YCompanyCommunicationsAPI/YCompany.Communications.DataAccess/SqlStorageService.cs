using YCompany.Communications.Domain.InfrastructureInterfaces;

namespace YCompany.Communications.DataAccess
{
    public class SqlStorageService : ICommunicationStorageService
    {
        public Task<bool> CheckHealthAsync()
        {
            return Task.FromResult(true);
        }
    }
}
