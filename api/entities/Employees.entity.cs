using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Entities
{
    public class Employees
    {
        [Key]
        public required int EmployeeID { get; set; }

        public required string? LastName { get; set; }

        public required string? FirstName { get; set; }

        public string? Title { get; set; }

        public string? TitleOfCourtesy { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? HomePhone { get; set; }

        public string? Extension { get; set; }

        public byte[]? Photo { get; set; }

        public string? Notes { get; set; }

        [ForeignKey("Employees")]
        public required int? ReportsTo { get; set; }

        public string? PhotoPath { get; set; }
    }
}