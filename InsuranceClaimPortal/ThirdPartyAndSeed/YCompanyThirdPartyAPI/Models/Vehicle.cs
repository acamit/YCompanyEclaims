using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using YCompanyThirdPartyAPI.Models;

namespace YCompanyPaymentsAPI.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public int VehicleYear { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public string? VehicleNumberPlate { get; set; }
        public bool Active { get; set; }

        [ForeignKey("Policy")]
        public int PolicyId { get; set; }
        [JsonIgnore]
        public Policy? Policy { get; set; }
        public ICollection<VehicleDriver>? VehicleDrivers { get; set; }
        public ICollection<VehicleCoverage>? VehicleCoverages { get; set; }

    }
}
