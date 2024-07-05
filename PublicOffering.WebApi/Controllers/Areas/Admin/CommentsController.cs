using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Public_Offering.Business.Abstract;

namespace Commenting.WebApi.Controllers.Areas.Admin
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
    }
}
