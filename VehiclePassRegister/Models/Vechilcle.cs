﻿using System.ComponentModel.DataAnnotations;

namespace VehiclePassRegister.Models
{
    public class Vechilcle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? VechicleNo { get; set; }
        public string? DriverName { get; set; }
        public int DriverPhoneNo { get; set; }
        public DateTime PassingTime { get; set; } = DateTime.UtcNow;

    }
}
