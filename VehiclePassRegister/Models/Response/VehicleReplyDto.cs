namespace VehiclePassRegister.Models.Response
{
    public class VehicleReplyDto
    {
        public int Id { get; set; }
        public string VechicleNo { get; set; }
        public string DriverName { get; set; }
        public int DriverPhoneNo { get; set; }
        public DateTime PassingTime { get; set; }
    }
}
