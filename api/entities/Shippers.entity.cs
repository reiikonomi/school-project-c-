using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Entities
{
    public class Shippers
    {
        [Key]
        public required int ShipperID { get; set; }

        public required string CompanyName { get; set; }  

        public string? Phone { get; set; } 
    }
}