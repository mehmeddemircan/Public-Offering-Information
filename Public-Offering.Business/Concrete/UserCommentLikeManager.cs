using AutoMapper;
using Public_Offering.Business.Abstract;
using Public_Offering.Business.Constants;
using Public_Offering.Core.Utilities.Results;
using Public_Offering.DataAccess.Abstract;
using Public_Offering.DataAccess.Concrete.EntityFramework;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.CommentDtos;
using Public_Offering.Types.DTOs.UserCommentLikeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Concrete
{
    public class UserCommentLikeManager : IUserCommentLikeService
    {

        IUserCommentLikeRepository _userCommentLikeRepository;
        IMapper _mapper; 

        public UserCommentLikeManager(IUserCommentLikeRepository userCommentLikeRepository,IMapper mapper )
        {
            _userCommentLikeRepository = userCommentLikeRepository;
             _mapper = mapper; 
        }
        public async Task<IResult> AddAsync(UserCommentLikeAddDto entity)
        {
            var newCommentUserLike = _mapper.Map<UserCommentLike>(entity);

            await _userCommentLikeRepository.AddAsync(newCommentUserLike);


            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _userCommentLikeRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete,Messages.Deleted);
        }
    }
}
