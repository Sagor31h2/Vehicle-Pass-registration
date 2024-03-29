﻿using System.ComponentModel.DataAnnotations;

namespace VehiclePassRegister.Models.Request
{
    public class VehicleCreateDto
    {
        [Required(ErrorMessage = "VechicleNo is requiesd")]
        [StringLength(50, MinimumLength = 2)]
        public string VechicleNo { get; set; }

        [Required(ErrorMessage = "DriverName is requiesd")]
        [StringLength(50, MinimumLength = 2)]
        public string DriverName { get; set; }
        public int DriverPhoneNo { get; set; }
    }
}
