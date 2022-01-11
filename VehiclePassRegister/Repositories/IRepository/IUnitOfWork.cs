namespace VehiclePassRegister.Services.IServices
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
    }
}
