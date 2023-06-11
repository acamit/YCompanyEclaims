using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace YCompanyPaymentsAPI.Models
{
    public class PolicyCoverage
    {
        [Key]
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Policy")]
        public int PolicyId { get; set; }
        [JsonIgnore]
        public Policy? Policy { get; set; }
        [ForeignKey("Coverage")]
        public int CoverageId { get; set; }
        [JsonIgnore]
        public Coverage? Coverage { get; set; }
    }
}
