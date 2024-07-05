using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Public_Offering.Business.Abstract;
using Public_Offering.Types.DTOs.CommentDtos;

namespace PublicO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentService _commentService; 
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetAllComment()
        {
            var result = await _commentService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddNewComment(CommentAddDto commentAddDto)
        {
            var result = await _commentService.AddAsync(commentAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpGet]
        [Route("[action]/{commentId:int}")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
            var result = await _commentService.GetByIdAsync(commentId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }




        [HttpDelete]
        [Route("[action]/{commentId:int}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var result = await _commentService.DeleteAsync(commentId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateComment([FromForm] CommentUpdateDto commentUpdateDto)
        {
            var result = await _commentService.UpdateAsync(commentUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
