using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Entities;

namespace YourNamespace
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerDemographics> CustomerDemographics { get; set; }
        public DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Territories> Territories { get; set; }

    }

}
