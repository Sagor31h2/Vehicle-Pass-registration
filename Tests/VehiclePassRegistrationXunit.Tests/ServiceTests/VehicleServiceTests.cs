namespace VehiclePassRegistrationXunit.Tests.ServiceTests
{
    public class VehicleServiceTests
    {
        private readonly VehicleService _vehicleService;

        private readonly Mock<IVehicleRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _iUnitOfWorkMock;
        private readonly IMapper _mapperMock;

        /*A thing to remember
        Mapper interface does provide DI and allows us to program by
        Abstraction but still requires us to Initialize the Mapping configuration at startup.

        Due to the same reason, IMapper can not be completely
        mocked by setting up a mock extension method in a regular way.

        Here we will instantiate the Automapper interface
        i.e IMapper as Singleton so that the same instance will be used as-is for all
        Test methods.[https://www.thecodebuzz.com/unit-test-mock-automapper-asp-net-core-imapper/]
         */

        public VehicleServiceTests()
        {
            if (_mapperMock == null)
            {
                var mappingConfig = new MapperConfiguration(
                    mc =>
                    {
                        mc.AddProfile(new VehicleProfile());
                    });

                IMapper mapper = mappingConfig.CreateMapper();
                _mapperMock = mapper;
            }
            _repositoryMock = new Mock<IVehicleRepository>();
            _iUnitOfWorkMock = new Mock<IUnitOfWork>();

            _vehicleService = new VehicleService(
                _repositoryMock.Object,
                _mapperMock,
                _iUnitOfWorkMock.Object);
        }

        //GetAllVehicle
        [Fact]
        public async Task GetAllVehicles_InPutTwoVehicle_ReturnsMappedVehicle()
        {
            _repositoryMock.Setup(r => r.GetAllVehicle())
                .ReturnsAsync(new List<Vehicle>() { new Vehicle(), new Vehicle() });

            var result = await _vehicleService.GetAllVehicles();

            result.Count().Should().Be(2);
        }

        [Fact]
        public async Task GetAllVehicles_InPutzeroVehicle_ReturnsMappedVehicle()
        {
            _repositoryMock.Setup(r => r.GetAllVehicle())
                .ReturnsAsync(() => null);

            var result = async () => await _vehicleService.GetAllVehicles();

            //var exception = await Assert.ThrowsAsync<AppException>(result);

            //Assert.Equal("Cant find the vehicles from data base", exception.Message);

            await result.Should().ThrowAsync<AppException>()
                .WithMessage("Cant find the vehicles from data base");
        }
    }
}