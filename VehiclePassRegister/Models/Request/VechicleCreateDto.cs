namespace VehiclePassRegister.Models.Request
{
    public class VechicleCreateDto
    {
        public string? VechicleNo { get; set; }
        public string? DriverName { get; set; }
        public int DriverPhoneNo { get; set; }
        public DateTime PassingTime { get; set; }
    }
}
