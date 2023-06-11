using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using YCompanyPaymentsAPI.Models;

namespace YCompanyThirdPartyAPI.Models
{
    public class VehicleDriver
    {
        [Key]
        public int Id { get; set; }
        public string? DriveForBusiness { get; set; }
        public bool IsPrimaryDriver { get; set; }
        public float EverydayMileage { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        [JsonIgnore]
        public Vehicle? Vehicle { get; set; }

        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        [JsonIgnore]
        public Driver? Driver { get; set; }


    }
}
