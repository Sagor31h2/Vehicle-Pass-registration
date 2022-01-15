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

        //getby Id
        public async Task<Vehicle> VehicleGetById(int id)
        {
            return await _dataContext.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        }
        //Delete
        public void DeleteVehicle(Vehicle vehicle)
        {
            
            _dataContext.Vehicles.Remove(vehicle);
        }
    }
}
