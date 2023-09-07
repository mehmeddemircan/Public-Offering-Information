using AutoMapper;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.CompanyDtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Mappings.CompanyProfile
{
    public class CompanyProfile  : Profile
    {

        public CompanyProfile()
        {
            CreateMap<CompanyAddDto, Company>();
            CreateMap<Company, CompanyAddDto>();

            CreateMap<CompanyUpdateDto, Company>();
            CreateMap<Company, CompanyUpdateDto>();

            CreateMap<CompaniesDto, Company>();
            CreateMap<Company, CompaniesDto>();

            CreateMap<CompanyDetailDto, Company>();
            CreateMap<Company, CompanyDetailDto>();
        }
    }
}
