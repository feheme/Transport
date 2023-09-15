using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.ReservationDtos;

namespace Transport.Business.Mappings
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationAddDto, Reservation>();
            CreateMap<Reservation, ReservationAddDto>();

            CreateMap<ReservationUpdateDto, Reservation>();
            CreateMap<Reservation, ReservationUpdateDto>();

            CreateMap<ReservationDetailDto, Reservation>();
            CreateMap<Reservation, ReservationDetailDto>()
                    .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));
        }
    }
}
