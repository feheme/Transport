﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete.Auth;
using Transport.Entities.DTOs.UserOperationClaimDtos;

namespace Transport.Business.Mappings
{
    public class UserOperationClaimProfile : Profile
    {
        public UserOperationClaimProfile()
        {
            CreateMap<UserOperationClaimAddDto, UserOperationClaim>();
            CreateMap<UserOperationClaim, UserOperationClaimAddDto>();

            CreateMap<UserOperationClaimUpdateDto, UserOperationClaim>();
            CreateMap<UserOperationClaim, UserOperationClaimUpdateDto>();

            CreateMap<UserOperationClaimDetailDto, UserOperationClaim>();
            CreateMap<UserOperationClaim, UserOperationClaimDetailDto>()

                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.OperationClaim.Name));
        }
    }
}
