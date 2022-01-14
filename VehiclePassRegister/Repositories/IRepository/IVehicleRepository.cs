using VehiclePassRegister.Models;

namespace VehiclePassRegister.Repositories.IRepository
{
    public interface IVehicleRepository
    {

        Task<IEnumerable<Vehicle>> GetAllVehicle();
        Task CreateVehicleInfo(Vehicle vehicle);

    }
}
