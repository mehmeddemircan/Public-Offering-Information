using Public_Offering.Core.Entities.Abstract;
using Public_Offering.Core.Entities.Concrete.Auth;
using Public_Offering.Types.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Types.DTOs.UserCommentLikeDtos
{
    public class UserCommentLikeAddDto : IDto
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }
     
    }
}
