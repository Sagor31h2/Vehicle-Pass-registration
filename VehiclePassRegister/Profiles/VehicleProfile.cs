using AutoMapper;
using VehiclePassRegister.Models;
using VehiclePassRegister.Models.Response;

namespace VehiclePassRegister.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleReplyDto>();
        }
    }
}
