using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.CommentDtos;

namespace Transport.Business.Mappings
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentAddDto, Comment>();
            CreateMap<Comment, CommentAddDto>();

            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Comment, CommentUpdateDto>();

            CreateMap<CommentDetailDto, Comment>();
            CreateMap<Comment, CommentDetailDto>()
                   .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                    .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.LastName));
        }
    }
}
