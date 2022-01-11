using AutoMapper;
using VehiclePassRegister.Models;
using VehiclePassRegister.Models.Response;
using VehiclePassRegister.Repositories.IRepository;
using VehiclePassRegister.Services.IServices;

namespace VehiclePassRegister.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IVehicleRepository _vehicleRepo;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepo,IMapper mapper)
        {

            _vehicleRepo = vehicleRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<VehicleReplyDto>> GetAllVehicles()
        {
           

            var vehicle = await _vehicleRepo.GetAllVehicle();
            var MappedVehicle = _mapper.Map<IEnumerable<VehicleReplyDto>>(vehicle);

            return MappedVehicle;
        }
    }
}
