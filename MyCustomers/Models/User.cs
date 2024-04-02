using System.ComponentModel.DataAnnotations;

namespace MyCustomers.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(128)]
        public string Password { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }

}
