﻿using Microsoft.AspNetCore.Mvc;
using VehiclePassRegister.Models.Response;
using VehiclePassRegister.Services.IServices;

namespace VehiclePassRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclePassController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public VehiclePassController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleReplyDto>>> GetAllVehicles()
        {


            var vehicles = await _unitOfWork.vehicleService
                .GetAllVehicles();

            return Ok(vehicles);

        }
    }
}
