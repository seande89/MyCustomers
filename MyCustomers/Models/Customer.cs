using System.ComponentModel.DataAnnotations;

namespace MyCustomers.Models
{
    // Define the Customer class
    public class Customer
    {
        [Key] // Specify that Id property is the primary key
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter First Name")] // Specify that FirstName property is required
        [StringLength(50)] // Specify maximum length of 50 characters for FirstName
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")] // Specify that LastName property is required
        [StringLength(50)] // Specify maximum length of 50 characters for LastName
        public string LastName { get; set; }

        [StringLength(int.MaxValue)] // Allow Address property to have maximum length
        public string? Address { get; set; }

        [StringLength(50)] // Specify maximum length of 50 characters for Email
        [EmailAddress] // Validate Email property as a valid email address
        public string? Email { get; set; }

        public int? Mobile { get; set; } // Allow Mobile property to be nullable

        public int? UserId { get; set; }

        public DateTime DateCreated { get; set; }


        public virtual List<Vehicle>? Vehicles { get; set; }
    }
}
