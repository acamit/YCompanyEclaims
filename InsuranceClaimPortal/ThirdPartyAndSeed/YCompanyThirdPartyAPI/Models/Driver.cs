using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using YCompanyThirdPartyAPI.Models;

namespace YCompanyPaymentsAPI.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DoB { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime LicenseIssuedDate { get; set; }
        public string? LicenseIssuedState { get; set; }
        public string? LicenseNumber { get; set; }
        public bool IsPrimaryPolicyHolder { get; set; }
        public string? RelationWithPrimaryPolicyHolder { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }

        [ForeignKey("Policy")]
        public int PolicyId { get; set; }
        [JsonIgnore]
        public Policy? Policy { get; set; }
        public ICollection<VehicleDriver>? VehicleDrivers { get; set; }
    }
}
