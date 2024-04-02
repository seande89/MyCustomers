using System.ComponentModel.DataAnnotations;

namespace MyCustomers.Models
{
    public class VehicleMake
    {
        [Key]
        public int VehicleMakeID { get; set; }
        [Required]
        [StringLength(50)]
        public string? Brand { get; set; }
    }
}
