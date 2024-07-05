using Public_Offering.Core.Entities.Concrete;
using Public_Offering.Core.Entities.Concrete.Auth;

namespace Public_Offering.Types.Concrete
{
    public class UserCommentLike : AuditableEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
