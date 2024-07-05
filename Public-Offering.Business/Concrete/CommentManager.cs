using AutoMapper;
using Public_Offering.Business.Abstract;
using Public_Offering.Business.Constants;
using Public_Offering.Core.Utilities.Results;
using Public_Offering.DataAccess.Abstract;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.CommentDtos;
using Public_Offering.Types.DTOs.CommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentRepository _commentRepository;
        IMapper _mapper; 
        public CommentManager(ICommentRepository commentRepository,IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(CommentAddDto entity)
        {
            var newComment = _mapper.Map<Comment>(entity);

            await _commentRepository.AddAsync(newComment);


            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _commentRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<CommentDetailDto>> GetAsync(Expression<Func<Comment, bool>> filter)
        {
            var comment = await _commentRepository.GetAsync(filter);
            if (comment != null)
            {
                var commentDetailDto = _mapper.Map<CommentDetailDto>(comment);
                return new SuccessDataResult<CommentDetailDto>(commentDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<CommentDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<CommentDetailDto>> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetAsync(x => x.Id == id);
            if (comment != null)
            {
                var commentDetailDto = _mapper.Map<CommentDetailDto>(comment);
                return new SuccessDataResult<CommentDetailDto>(commentDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<CommentDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<CommentsDto>>> GetListAsync(Expression<Func<Comment, bool>> filter = null)
        {
            if (filter == null)
            {
                // Exception 
                //throw new UnauthorizedAccessException("UnAuthorized"); 
                var response = await _commentRepository.GetListAsync();
                var responseDetailDto = _mapper.Map<IEnumerable<CommentsDto>>(response);
                return new SuccessDataResult<IEnumerable<CommentsDto>>(responseDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _commentRepository.GetListAsync(filter);
                var responseDetailDto = _mapper.Map<IEnumerable<CommentsDto>>(response);
                return new SuccessDataResult<IEnumerable<CommentsDto>>(responseDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<CommentUpdateDto>> UpdateAsync(CommentUpdateDto commentUpdateDto)
        {
            var getComment = await _commentRepository.GetAsync(x => x.Id == commentUpdateDto.Id);

            var comment = _mapper.Map<Comment>(commentUpdateDto);


            comment.UpdatedDate = DateTime.Now;
            comment.UpdatedBy = 1;


            var commentUpdate = await _commentRepository.UpdateAsync(comment);
            var resultUpdateDto = _mapper.Map<CommentUpdateDto>(commentUpdate);

            return new SuccessDataResult<CommentUpdateDto>(resultUpdateDto, Messages.Updated);
        }
    }
}
