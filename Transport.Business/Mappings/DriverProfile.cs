using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.DriverDtos;

namespace Transport.Business.Mappings
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {

            CreateMap<DriverAddDto, Driver>();
            CreateMap<Driver, DriverAddDto>();

            CreateMap<DriverUpdateDto, Driver>();
            CreateMap<Driver, DriverUpdateDto>();

            CreateMap<DriverDetailDto, Driver>();
            CreateMap<Driver, DriverDetailDto>()
                    .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName));

        }
    }
}
