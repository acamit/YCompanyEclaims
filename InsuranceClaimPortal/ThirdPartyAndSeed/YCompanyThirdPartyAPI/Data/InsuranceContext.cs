using Microsoft.EntityFrameworkCore;
using YCompanyPaymentsAPI.Models;
using YCompanyThirdPartyAPI.Models;

namespace YCompanyPaymentsAPI.Data
{

    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options) { }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>()
                .HasOne(v => v.Vehicle)
                .WithOne(a => a.Policy)
                .HasForeignKey<Vehicle>(a => a.PolicyId);

            modelBuilder.Entity<Policy>()
                .HasMany(v => v.Drivers)
                .WithOne(a => a.Policy)
                .HasForeignKey(a => a.PolicyId);

            modelBuilder.Entity<PolicyCoverage>().HasKey(pc => new { pc.Id });

            modelBuilder.Entity<PolicyCoverage>()
            .HasOne(p => p.Policy)
            .WithMany(a => a.PolicyCoverages)
            .HasForeignKey(a => a.PolicyId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<PolicyCoverage>()
            .HasOne(p => p.Coverage)
            .WithMany(a => a.PolicyCoverages)
            .HasForeignKey(a => a.CoverageId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<VehicleDriver>().HasKey(vd => new { vd.Id });

            modelBuilder.Entity<VehicleDriver>()
            .HasOne(p => p.Vehicle)
            .WithMany(a => a.VehicleDrivers)
            .HasForeignKey(a => a.VehicleId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<VehicleDriver>()
            .HasOne(p => p.Driver)
            .WithMany(a => a.VehicleDrivers)
            .HasForeignKey(a => a.DriverId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<VehicleCoverage>().HasKey(vc => new { vc.Id });

            modelBuilder.Entity<VehicleCoverage>()
            .HasOne(p => p.Vehicle)
            .WithMany(a => a.VehicleCoverages)
            .HasForeignKey(a => a.VehicleId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<VehicleCoverage>()
            .HasOne(p => p.Coverage)
            .WithMany(a => a.VehicleCoverages)
            .HasForeignKey(a => a.CoverageId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}