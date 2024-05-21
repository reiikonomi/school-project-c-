using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Entities
{
    public class Orders
    {
        [Key]
        public required int OrderID { get; set; }

        [ForeignKey("Customers")]
        public required string CustomerID { get; set; }

        [ForeignKey("Employees")]
        public required int EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        [ForeignKey("Shippers")]
        public required int ShipVia { get; set; }

        public decimal? Freight { get; set; }

        public string? ShipName { get; set; }

        public string? ShipAddress { get; set; }

        public string? ShipCity { get; set; }

        public string? ShipRegion { get; set; }

        public string? ShipPostalCode { get; set; }

        public string? ShipCountry { get; set; }


    }
}