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
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IVehicleRepository vehicleRepo,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _vehicleRepo = vehicleRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<VehicleReplyDto>> GetAllVehicles()
        {
           
            var vehicle = await _vehicleRepo.GetAllVehicle();
            var MappedVehicle = _mapper.Map<IEnumerable<VehicleReplyDto>>(vehicle);

            return MappedVehicle;
        }
    }
}
