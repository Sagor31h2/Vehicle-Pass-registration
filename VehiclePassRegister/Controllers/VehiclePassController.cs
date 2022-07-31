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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleReplyDto>>> GetAllVehicles()
        {

            var vehicles = await _vehicleService.GetAllVehicles();
            _logger.LogInformation($"Returned {vehicles.Count()} vehicle information from database");

            return Ok(vehicles);


        }

        //create
        [HttpPost()]
        public async Task<IActionResult> CreateVehicleInfo([FromBody] VehicleCreateDto vehicleCreateDto)
        {


            if (!ModelState.IsValid)
            {
                _logger.LogError("Vehicle model state is invalid");
                return BadRequest("Model state is invalid");

            }
            else
            {
                await _vehicleService.CreateVehicleInfo(vehicleCreateDto);
                _logger.LogInformation("Vehicle info created");
                return Ok();
            }
        }

        //GetbyId
        [HttpGet("{id}", Name = "GetVehicleById")]
        public async Task<ActionResult<VehicleReplyDto>> VehicleGetById(int id)
        {

            var vehiclebyid = await _vehicleService.VehicleGetById(id);
            _logger.LogInformation($"Vehicle details with id:{id}");
            return Ok(vehiclebyid);
        }




        //update
        [HttpPut("{id}", Name = "Update")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleUpdateDto updateDto)
        {

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("vehicle modestate is invalid");
                return BadRequest();
            }
            else
            {
                await _vehicleService.UpdateVehicle(id, updateDto);
                _logger.LogInformation($"vehile id : {id} is updated ");
                return Ok();
            }

        }

        //Delete
        [HttpDelete("{id}", Name = "Delete")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            await _vehicleService.DeleteVehicle(id);
            _logger.LogInformation($"vehicle information with id: {id} is deleted");
            return Ok();


        }

    }
}
