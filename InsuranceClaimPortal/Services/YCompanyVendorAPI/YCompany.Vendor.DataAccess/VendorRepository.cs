using YCompany.Vendor.Domain.InfrastructureInterfaces.Repositories;

namespace YCompany.Vendor.DataAccess
{
    internal sealed class VendorRepository : IVendorRepository
    {

        private readonly RepositoryDbContext _dbContext;
        public VendorRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;


    }
}