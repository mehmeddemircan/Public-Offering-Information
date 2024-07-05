using Public_Offering.Core.Entities.Concrete;
using Public_Offering.Core.Entities.Concrete.Auth;
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

        public int UserId { get; set; }
        public User User { get; set; }

        public int PublicOfferId { get; set; }
        public virtual PublicOffer PublicOffer { get; set; }
        public string CommentText { get; set; }
        public ICollection<UserCommentLike> LikedByUsers { get; set; } = new List<UserCommentLike>();
        public int LikeCount { get; set; } = 0;

        //public int DisLikeCount { get; set; } = 0;
        //public ICollection<UserCommentLike> LikedByUsers { get; set; } = new List<UserCommentLike>();
    }
}
