using System.ComponentModel.DataAnnotations;

namespace YCompanyPaymentsAPI.Models
{
    public class Policy
    {
        [Key]
        public int Id { get; set; }
        public string PolicyName { get; set; } = string.Empty;
        public int PolicyNumber { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpirationDate { get; set; }
        public string PaymentOption { get; set; } = string.Empty;
        public double TotalAmount { get; set; }
        public bool Active { get; set; }
        public string AdditionalInfo { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public Vehicle? Vehicle { get; set; }
        public ICollection<Driver>? Drivers { get; set; }
        public ICollection<PolicyCoverage>? PolicyCoverages { get; set; }
    }
}
