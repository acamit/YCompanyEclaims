using YCompany.Reporting.Domain.InfrastructureInterfaces.Repositories;

namespace YCompany.Reporting.DataAccess
{
    internal sealed class ReportingRepository : IReportingRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public ReportingRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
    }
}