using YCompany.UserManagement.Domain.InfrastructureInterfaces;

namespace YCompany.UserManagement.DataAccess
{
    public class SqlStorageService : IUserManagementStorageService
    {
        public Task<bool> CheckHealthAsync()
        {
            return Task.FromResult(true);
        }
    }
}
