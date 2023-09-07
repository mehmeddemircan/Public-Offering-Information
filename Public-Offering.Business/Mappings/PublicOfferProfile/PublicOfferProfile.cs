using AutoMapper;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.PublicOfferDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Mappings.PublicOfferProfile  
{
    public class PublicOfferProfile : Profile
    { 
        //Todo : Mapperde formembera bakılacak , ve dto kısmında for member şeklinde yapılıp test edilecek 
        //Todo : PublicOfferDetailDtoda da company verileri getirilecek 

        public PublicOfferProfile()
        {
            CreateMap<PublicOfferAddDto, PublicOffer>();
            CreateMap<PublicOffer, PublicOfferAddDto>();

            CreateMap<PublicOfferUpdateDto, PublicOffer>();
            CreateMap<PublicOffer, PublicOfferUpdateDto>();

            CreateMap<PublicOffersDto, PublicOffer>();
            CreateMap<PublicOffer, PublicOffersDto>().ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));
               

            CreateMap<PublicOfferDetailDto, PublicOffer>();
            CreateMap<PublicOffer, PublicOfferDetailDto>();
        }
    }
}
