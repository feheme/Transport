using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.CompanyDtos;

namespace Transport.Business.Mappings
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyAddDto, Company>();
            CreateMap<Company, CompanyAddDto>();

            CreateMap<CompanyUpdateDto, Company>();
            CreateMap<Company, CompanyUpdateDto>();

            CreateMap<CompanyDetailDto, Company>();
            CreateMap<Company, CompanyDetailDto>();

        }
    }
}
