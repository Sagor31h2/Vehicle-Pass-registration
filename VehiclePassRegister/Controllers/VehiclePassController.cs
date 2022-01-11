using Microsoft.AspNetCore.Mvc;
using VehiclePassRegister.Models.Response;
using VehiclePassRegister.Services.IServices;

namespace VehiclePassRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclePassController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;


        public VehiclePassController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleReplyDto>>> GetAllVehicles()
        {
                var vehicles = await _vehicleService.GetAllVehicles();

                return Ok(vehicles);
                  
        }
    }
}
