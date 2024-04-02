using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCustomers.Models
{
    public class Vehicle
    {
        [Key]
        [Required]
        public int VehicleID { get; set; }

        [Required]
        public int CustomerID { get; set; }
        [Required]
        public int VehicleMakeID { get; set; }
        [Required]
        public string VehicleModel { get; set; }
        [Required]
        public int VehicleYear { get; set; }
        [Required]
        public string VehicleIDNum { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public string VehiclePlateNum { get; set; }


        [ForeignKey(nameof(VehicleMakeID))]
        public virtual VehicleMake? VehicleMake { get; set; }
    }
}
