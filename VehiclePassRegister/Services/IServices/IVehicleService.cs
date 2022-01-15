using VehiclePassRegister.Models;
using VehiclePassRegister.Models.Request;
using VehiclePassRegister.Models.Response;

namespace VehiclePassRegister.Services.IServices
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleReplyDto>> GetAllVehicles();

        Task CreateVehicleInfo(VehicleCreateDto vechicleCreateDto);
        Task<VehicleReplyDto> VehicleGetById(int id);
        Task UpdateVehicle(int id, VehicleUpdateDto updateDto);
        Task DeleteVehicle(int id);
    }
}
