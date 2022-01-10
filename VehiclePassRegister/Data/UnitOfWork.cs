using VehiclePassRegister.Services;
using VehiclePassRegister.Services.IServices;

namespace VehiclePassRegister.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        
        public IVehicleService vehicleService { get; }

        public UnitOfWork(DataContext dataContext, IVehicleService vehicleService)
        {
            _dataContext = dataContext;
            this.vehicleService = vehicleService;
        }


        public async Task<bool> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
