using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.VehicleDtos;

namespace Transport.Business.Mappings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleAddDto, Vehicle>();
            CreateMap<Vehicle, VehicleAddDto>();

            CreateMap<VehicleUpdateDto, Vehicle>();
            CreateMap<Vehicle, VehicleUpdateDto>();

            CreateMap<VehicleDetailDto, Vehicle>();
            CreateMap<Vehicle, VehicleDetailDto>()
                    .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName));
        }
    }
}
