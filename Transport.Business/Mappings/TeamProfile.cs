using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.TeamDtos;

namespace Transport.Business.Mappings
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamAddDto, Team>();
            CreateMap<Team, TeamAddDto>();

            CreateMap<TeamUpdateDto, Team>();
            CreateMap<Team, TeamUpdateDto>();

            CreateMap<TeamDetailDto, Team>();
            CreateMap<Team, TeamDetailDto>()
                    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName));
        }
    }
}
