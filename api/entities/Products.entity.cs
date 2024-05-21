using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Entities
{
    public class Products
    {
        [Key]
        public required int ProductID { get; set; }

        public required string ProductName { get; set; }

        [ForeignKey("Suppliers")]
        public required int SupplierID { get; set; }

        [ForeignKey("Categories")]
        public required int CategoryID { get; set; }

        public string? QuantityPerUnit { get; set; }

        public Decimal? UnitPrice { get; set; }

        public Int16? UnitsInStock { get; set; }

        public Int16? UnitsOnOrder { get; set; }

        public Int16? ReorderLevel { get; set; }

        public bool? Discontinued { get; set; }


    }
}