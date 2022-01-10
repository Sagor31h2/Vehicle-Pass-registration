namespace VehiclePassRegister.Services.IServices
{
    public interface IUnitOfWork
    {
        IVehicleService vehicleService { get; }
        Task<bool> SaveAsync();
    }
}
