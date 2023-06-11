using YCompany.Communications.Domain.InfrastructureInterfaces.Repositories;

namespace YCompany.Communications.DataAccess
{
    internal sealed class CommunicationsRepository : ICommunicationsRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public CommunicationsRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
    }
}