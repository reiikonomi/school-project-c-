using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Entities
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required string Description { get; set; }
    }
}