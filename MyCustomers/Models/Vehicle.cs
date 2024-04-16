﻿using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Please enter the model of the vehicle")]
        public string VehicleModel { get; set; }
        [Required(ErrorMessage = "Please enter a year")]
        [Range(1920, 2124, ErrorMessage = "Year must be after 1920")]
        public int VehicleYear { get; set; }
        [Required(ErrorMessage = "Please enter the VIN or chassis number")]
        public string VehicleIDNum { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Please enter the license plate number")]
        public string VehiclePlateNum { get; set; }


        [ForeignKey(nameof(VehicleMakeID))]
        public virtual VehicleMake? VehicleMake { get; set; }

    }
}
