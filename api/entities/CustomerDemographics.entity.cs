using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Entities
{
    public class CustomerDemographics
    {
        [Key]
        public string? CustomerTypeId { get; set; }
        public required string CustomerDesc { get; set; }
    }
}