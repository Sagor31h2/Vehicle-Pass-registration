using AutoMapper;
using VehiclePassRegister.Models;
using VehiclePassRegister.Models.Request;
using VehiclePassRegister.Models.Response;

namespace VehiclePassRegister.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleReplyDto>();
            CreateMap<VehicleCreateDto, Vehicle>();
            CreateMap<VehicleUpdateDto, Vehicle>();

        }
    }
}
