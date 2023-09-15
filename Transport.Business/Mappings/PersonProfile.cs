using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.PersonDtos;

namespace Transport.Business.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonAddDto, Person>();
            CreateMap<Person, PersonAddDto>();

            CreateMap<PersonUpdateDto, Person>();
            CreateMap<Person, PersonUpdateDto>();

            CreateMap<PersonDetailDto, Person>();
            CreateMap<Person, PersonDetailDto>()
                    .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName));
        }
    }
}
