using YCompany.Claims.Domain.InfrastructureInterfaces.Repositories;

namespace YCompany.Claims.DataAccess
{
    internal sealed class ClaimsRepository : IClaimRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public ClaimsRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
    }
}
