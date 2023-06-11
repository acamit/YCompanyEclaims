using Microsoft.EntityFrameworkCore;
using YCompany.Payments.Domain.Enitites;

namespace YCompany.Payments.DataAccess
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Payment>? Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
    }
}
