using Public_Offering.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Types.Concrete
{
    public class Comment : AuditableEntity
    {
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public string CommentText { get; set; }

        public List<Comment> ChildComments { get; set; } = new List<Comment>();

        //public int LikeCount { get; set; } = 0;
        //public int DisLikeCount { get; set; } = 0;
        //public ICollection<UserCommentLike> LikedByUsers { get; set; } = new List<UserCommentLike>();
    }
}
