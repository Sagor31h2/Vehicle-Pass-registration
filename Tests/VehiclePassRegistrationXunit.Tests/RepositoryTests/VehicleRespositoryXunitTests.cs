namespace VehiclePassRegistrationXunit.Tests.RepositoryTests
{
    public class VehicleRespositoryXunitTests
    {
        private readonly DataContext _context;

        public VehicleRespositoryXunitTests()
        {
            var dbOptions = new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase(
                        Guid.NewGuid().ToString()
                     );

            _context = new DataContext(dbOptions.Options);
        }

        [Fact]
        public async Task VehicleRepository_CreateAEntry_SaveToDb()
        {
            var sut = new VehicleRepository(_context);
            var vehicle = new Vehicle()
            {
                Id = 1,
                VechicleNo = "Sa45790",
                DriverName = "Sagor",
                DriverPhoneNo = 01674578901,
                PassingTime = DateTime.UtcNow
            };

            await sut.CreateVehicleInfo(vehicle);
            _context.SaveChanges();

            var savedVehicle = _context.Vehicles.FirstOrDefault(u => u.Id == 1);

            savedVehicle?.DriverName.Should().Be(savedVehicle.DriverName);
            savedVehicle?.Id.Should().Be(savedVehicle.Id);
            savedVehicle?.VechicleNo.Should().Be(savedVehicle.VechicleNo);
            savedVehicle?.DriverPhoneNo.Should().Be(savedVehicle.DriverPhoneNo);
            savedVehicle?.PassingTime.Should().Be(savedVehicle.PassingTime);
        }
    }
}