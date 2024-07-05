using Public_Offering.Core.Utilities.Results;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.CommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Abstract
{
    public interface ICommentService
    {

        Task<IResult> AddAsync(CommentAddDto entity);


        Task<IDataResult<IEnumerable<CommentsDto>>> GetListAsync(Expression<Func<Comment, bool>> filter = null);
        Task<IDataResult<CommentDetailDto>> GetAsync(Expression<Func<Comment, bool>> filter);

        Task<IDataResult<CommentDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<CommentUpdateDto>> UpdateAsync(CommentUpdateDto commentUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
