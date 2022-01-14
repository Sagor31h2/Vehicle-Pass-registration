using Microsoft.EntityFrameworkCore;
using VehiclePassRegister.Data;
using VehiclePassRegister.Models;
using VehiclePassRegister.Repositories.IRepository;

namespace VehiclePassRegister.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataContext _dataContext;

        public VehicleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicle()
        {
            return await _dataContext.Vehicles.ToListAsync();
        }

        //create
        public async Task CreateVehicleInfo(Vehicle vehicle)
        {
            await _dataContext.Vehicles.AddAsync(vehicle);
        }
    }
}
