using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Entities
{
    public class EmployeeTerritories
    {
        [Key]
        [ForeignKey("Employees")]
        public required int EmployeeID { get; set; }

        [ForeignKey("Territories")]
        public required string TerritoryID { get; set; }

    }
}