using Microsoft.AspNetCore.Mvc;
using VehiclePassRegister.Models.Request;
using VehiclePassRegister.Models.Response;
using VehiclePassRegister.Services.IServices;

namespace VehiclePassRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclePassController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<VehiclePassController> _logger;

        public VehiclePassController(IVehicleService vehicleService, ILogger<VehiclePassController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }
        
        //[HttpPost()]
        //public async Task<IActionResult>CreateVehicleInfo([FromBody] VechicleCreateDto vechicleCreateDto)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleReplyDto>>> GetAllVehicles()
        {
            try
            {
                var vehicles = await _vehicleService.GetAllVehicles();
                _logger.LogInformation($"Returned {vehicles.Count()} vehicle information from database");

                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();

            }

        }
    }
}
