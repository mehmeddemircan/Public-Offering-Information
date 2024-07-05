using Public_Offering.Core.Entities.Abstract;
using Public_Offering.Types.Concrete;

namespace Public_Offering.Types.DTOs.CommentDtos
{
    public class CommentUpdateDto : IDto
    {
        //public int CommentId { get; set; }
        //public int UserId { get; set; }
        public int Id { get; set; }
        public int? ParentCommentId { get; set; }
        public int UserId { get; set; }
        public int PublicOfferId { get; set; }
        public string CommentText { get; set; }
    }
}
