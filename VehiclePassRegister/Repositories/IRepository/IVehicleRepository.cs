using VehiclePassRegister.Models;

namespace VehiclePassRegister.Repositories.IRepository
{
    public interface IVehicleRepository
    {

        Task<IEnumerable<Vehicle>> GetAllVehicle();
        Task CreateVehicleInfo(Vehicle vehicle);
        Task<Vehicle> VehicleGetById(int id);
        void DeleteVehicle(Vehicle vehicle);

    }
}
