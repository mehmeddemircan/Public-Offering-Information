using AutoMapper;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.UserCommentLikeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Mappings
{

    public class UserCommentLikeProfile : Profile
    {

        public UserCommentLikeProfile()
        {
            CreateMap<UserCommentLikeAddDto, UserCommentLike>();
            CreateMap<UserCommentLike, UserCommentLikeAddDto>();
        }
    }
}
