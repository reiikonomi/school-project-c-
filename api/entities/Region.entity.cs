using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Entities
{
    public class Region
    {
        [Key]
        public required int RegionID { get; set; }

        public required string RegionDescription { get; set; }

    }
}