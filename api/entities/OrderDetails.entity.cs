using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Entities
{
    public class OrderDetails
    {
        [Key]
        public required int OrderID { get; set; }

        [ForeignKey("Products")]
        public required int ProductID { get; set; }

        public string? UnitPrice { get; set; }

        public string? Quantity { get; set; }

        public string? Discount { get; set; }
    }
}