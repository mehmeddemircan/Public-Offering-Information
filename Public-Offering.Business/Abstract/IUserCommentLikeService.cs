using Public_Offering.Core.Utilities.Results;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.CommentDtos;
using Public_Offering.Types.DTOs.UserCommentLikeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Abstract
{
    public interface IUserCommentLikeService
    {
        Task<IResult> AddAsync(UserCommentLikeAddDto entity);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
