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

        //create
        [HttpPost()]
        public async Task<IActionResult> CreateVehicleInfo([FromBody] VehicleCreateDto vehicleCreateDto)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        //GetbyId
        [HttpGet("{id}", Name = "GetVehicleById")]
        public async Task<ActionResult<VehicleReplyDto>> VehicleGetById(int id)
        {
            try
            {
                var vehiclebyid = await _vehicleService.VehicleGetById(id);
                _logger.LogInformation($"Vehicle details with id:{ id}");
                return Ok(vehiclebyid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");

            }
        }

        //update
        [HttpPut("{id}", Name = "Update")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleUpdateDto updateDto)
        {
            try
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
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        //Delete
        [HttpDelete("{id}", Name = "Delete")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            try
            {
                await _vehicleService.DeleteVehicle(id);
                _logger.LogInformation($"vehicle information with id: {id} is deleted");
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

    }
}
