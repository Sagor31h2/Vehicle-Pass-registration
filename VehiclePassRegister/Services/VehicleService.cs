using VehiclePassRegister.Models;
using VehiclePassRegister.Repositories.IRepository;
using VehiclePassRegister.Services.IServices;

namespace VehiclePassRegister.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IVehicleRepository _vehicleRepo;

        public VehicleService(IVehicleRepository vehicleRepo)
        {

            _vehicleRepo = vehicleRepo;
        }
        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            var vehicle = await _vehicleRepo.GetAllVehicle();

            return vehicle;
        }
    }
}
