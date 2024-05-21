using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Entities
{
    public class Territories
    {
        [Key]
        public required string TerritoryID { get; set; }

        public required string TerritoryDescription { get; set; }

        [ForeignKey("Region")]
        public required int RegionID { get; set; }
    }
}