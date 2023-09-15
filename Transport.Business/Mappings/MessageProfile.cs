using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.MessageDtos;

namespace Transport.Business.Mappings
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageAddDto, Message>();
            CreateMap<Message, MessageAddDto>();

            CreateMap<MessageUpdateDto, Message>();
            CreateMap<Message, MessageUpdateDto>();

            CreateMap<MessageDetailDto, Message>();
            CreateMap<Message, MessageDetailDto>()
                    .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));
        }
    }
}
