﻿using AutoMapper;
using VehiclePassRegister.Models;
using VehiclePassRegister.Models.Request;
using VehiclePassRegister.Models.Response;
using VehiclePassRegister.Repositories.IRepository;
using VehiclePassRegister.Services.IServices;

namespace VehiclePassRegister.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IVehicleRepository _vehicleRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<VehicleService> _logger;

        public VehicleService(IVehicleRepository vehicleRepo, IMapper mapper, IUnitOfWork unitOfWork, ILogger<VehicleService> logger)
        {
            _vehicleRepo = vehicleRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<VehicleReplyDto>> GetAllVehicles()
        {

            var vehicle = await _vehicleRepo.GetAllVehicle();
            if (vehicle == null)
            {
                throw new Exception("Cant find the vehicles from data base");
            }
            else
            {
                var MappedVehicle = _mapper.Map<IEnumerable<VehicleReplyDto>>(vehicle);

                return MappedVehicle;
            }
        }

        //Create 

        public async Task CreateVehicleInfo(VehicleCreateDto vehicleCreateDto)
        {
            if (CreateVehicleInfo == null)
            {
                throw new Exception("Vehicle info is empty");
                
            }
            var CtreateDto = _mapper.Map<Vehicle>(vehicleCreateDto);

            await _vehicleRepo.CreateVehicleInfo(CtreateDto);

            var save = await _unitOfWork.SaveAsync();
            if (!save)
            {
                throw new Exception("error in saving");
            }
        }
    }
}
