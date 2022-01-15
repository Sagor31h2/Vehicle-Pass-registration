using System.ComponentModel.DataAnnotations;

namespace VehiclePassRegister.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VechicleNo { get; set; }

        [Required]
        public string DriverName { get; set; }
        [Required]
        public int DriverPhoneNo { get; set; }
        public DateTime PassingTime { get; set; } = DateTime.UtcNow;

    }
}
