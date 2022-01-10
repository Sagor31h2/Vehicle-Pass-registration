using VehiclePassRegister.Models;
using VehiclePassRegister.Models.Response;

namespace VehiclePassRegister.Services.IServices
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllVehicles();
    }
}
