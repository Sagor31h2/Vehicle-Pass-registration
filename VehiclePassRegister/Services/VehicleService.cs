﻿using AutoMapper;
using VehiclePassRegister.Exceptions;
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

        public VehicleService(IVehicleRepository vehicleRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _vehicleRepo = vehicleRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleReplyDto>> GetAllVehicles()
        {
            var vehicle = await _vehicleRepo.GetAllVehicle();
            if (vehicle == null)
            {
                throw new AppException("Cant find the vehicles from data base");
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
                throw new AppException("Vehicle info is empty");
            }
            var CtreateDto = _mapper.Map<Vehicle>(vehicleCreateDto);

            await _vehicleRepo.CreateVehicleInfo(CtreateDto);

            var save = await _unitOfWork.SaveAsync();
            if (!save)
            {
                throw new AppException("error in saving");
            }
        }

        //GetById
        public async Task<VehicleReplyDto> VehicleGetById(int id)
        {
            var findVehicle = await FindVehicle(id);
            if (findVehicle == null)
            {
                throw new KeyNotFoundException("Cant find vehicle");
            }
            else
            {
                var mappedVehicle = _mapper.Map<VehicleReplyDto>(findVehicle);
                return mappedVehicle;
            }
        }

        //update
        public async Task UpdateVehicle(int id, VehicleUpdateDto updateDto)
        {
            var findVehicle = await FindVehicle(id);

            _mapper.Map(updateDto, findVehicle);

            var save = await _unitOfWork.SaveAsync();
            if (!save)
            {
                throw new AppException("cant save");
            }
        }

        //Delete
        public async Task DeleteVehicle(int id)
        {
            var findVehicle = await FindVehicle(id);
            _vehicleRepo.DeleteVehicle(findVehicle);

            var save = await _unitOfWork.SaveAsync();
            if (!save)
            {
                throw new AppException("cant Delete");
            }
        }

        //find vehicle
        private async Task<Vehicle> FindVehicle(int id)
        {
            return await _vehicleRepo.VehicleGetById(id);
        }
    }
}