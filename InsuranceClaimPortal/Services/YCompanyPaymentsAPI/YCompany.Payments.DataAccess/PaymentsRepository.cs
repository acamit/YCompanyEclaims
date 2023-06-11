using YCompany.Payments.Domain.InfrastructureInterfaces.Repositories;

namespace YCompany.Payments.DataAccess
{
    internal sealed class PaymentsRepository : IPaymentRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public PaymentsRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
    }
}