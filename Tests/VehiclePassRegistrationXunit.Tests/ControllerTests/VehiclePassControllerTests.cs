namespace VehiclePassRegistrationXunit.Tests.ControllerTests
{
    public class VehiclePassControllerTests
    {
        private readonly VehiclePassController _vehiclePassController;
        private readonly Mock<IVehicleService> _vehicleServiceMock;
        private readonly Mock<ILogger<VehiclePassController>> _loggerMock;

        public VehiclePassControllerTests()
        {
            _vehicleServiceMock = new Mock<IVehicleService>();
            _loggerMock = new Mock<ILogger<VehiclePassController>>();

            _vehiclePassController = new VehiclePassController(
                _vehicleServiceMock.Object,
                _loggerMock.Object);
        }

        //GetAll
        [Fact]
        public async Task GetAllVehicles_InputTwoVehicle_ReturnsStatusCodeAndList()
        {
            _vehicleServiceMock.Setup(s => s.GetAllVehicles())
                .ReturnsAsync(new List<VehicleReplyDto>() {
                    new VehicleReplyDto(), new VehicleReplyDto()
                });

            var result = await _vehiclePassController.GetAllVehicles() as ActionResult<IEnumerable<VehicleReplyDto>>;

            var okResult = result.Result as OkObjectResult;

            okResult?.StatusCode.Should().Be(200);

            var returnVehicles = okResult?.Value as IEnumerable<VehicleReplyDto>;

            returnVehicles?.Count().Should().Be(2);
        }
    }
}