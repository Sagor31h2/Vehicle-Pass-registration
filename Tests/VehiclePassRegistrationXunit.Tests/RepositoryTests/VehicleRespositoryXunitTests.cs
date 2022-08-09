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

        //GetAll
        [Fact]
        public async Task GetAllVehicle_InputAListofVehicle_GetAll()
        {
            var sut = new VehicleRepository(_context);
            var vehicles = new List<Vehicle>()
            {
                new Vehicle()
                {
                    Id = 1,
                    VechicleNo = "Sa45790",
                    DriverName = "Sagor",
                    DriverPhoneNo = 01674578901,
                    PassingTime = DateTime.UtcNow
                },
                 new Vehicle()
                {
                    Id = 2,
                    VechicleNo = "tu45790",
                    DriverName = "tusher",
                    DriverPhoneNo = 01674578901,
                    PassingTime = DateTime.UtcNow
                }
            };

            await _context.AddRangeAsync(vehicles);
            _context.SaveChanges();

            var result = await sut.GetAllVehicle();

            result.Should().BeEquivalentTo(vehicles);
        }

        //GetById
        [Fact]
        public async Task GetById_SaveAVehicle_GetItById()
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

            await _context.AddRangeAsync(vehicle);
            _context.SaveChanges();

            var result = await sut.VehicleGetById(1);

            result.Should().BeEquivalentTo(vehicle);
            result.DriverName.Should().Be(vehicle.DriverName);
        }

        //DeleteAnd check
        [Fact]
        public async Task DeleteVehicle_Delete_GetNull()
        {
            var sut = new VehicleRepository(_context);
            var vehicle = new Vehicle()
            {
                Id = 12,
                VechicleNo = "Sa45790",
                DriverName = "Sagor",
                DriverPhoneNo = 01674578901,
                PassingTime = DateTime.UtcNow
            };

            await _context.AddAsync(vehicle);
            _context.SaveChanges();

            sut.DeleteVehicle(vehicle);

            _context.SaveChanges();

            var result = await _context.Vehicles.FindAsync(12);
            result.Should().BeNull();
        }
    }
}