using Microsoft.EntityFrameworkCore;
using MyCustomers.Models; // Make sure to replace YourNamespace with the actual namespace of your models

// Define the namespace for the MyCustomersDbContext class
namespace MyCustomers.Models
{
    // Define the MyCustomersDbContext class that inherits from DbContext
    public partial class MyCustomersDbContext : DbContext
    {
        // Default constructor for MyCustomersDbContext
        public MyCustomersDbContext()
        {
        }

        // Constructor with options for MyCustomersDbContext
        public MyCustomersDbContext(DbContextOptions<MyCustomersDbContext> options)
            : base(options)
        {
        }

        // Define a DbSet for the Customer entity
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }


        // Partial method for OnModelCreating, which can be extended in partial classes
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
