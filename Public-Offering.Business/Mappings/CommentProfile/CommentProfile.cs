using AutoMapper;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.CommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Mappings.CommentProfile
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentAddDto, Comment>();
            CreateMap<Comment, CommentAddDto>();

            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Comment, CommentUpdateDto>();

            CreateMap<CommentsDto, Comment>();
            CreateMap<Comment, CommentsDto>();

            CreateMap<CommentDetailDto, Comment>();
            CreateMap<Comment, CommentDetailDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));
        }
    }
}
