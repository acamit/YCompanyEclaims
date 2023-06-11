using System.ComponentModel.DataAnnotations;

namespace YCompanyPaymentsAPI.Models
{
    public class Coverage
    {
        [Key]
        public int Id { get; set; }
        public string? CoverageName { get; set; }
        public string? CoverageGroup { get; set; }
        public string? Code { get; set; }
        public bool IsPolicyCoverage { get; set; }
        public bool IsVehicleCoverage { get; set; }
        public ICollection<PolicyCoverage>? PolicyCoverages { get; set; }
        public ICollection<VehicleCoverage>? VehicleCoverages { get; set; }
    }
}
