using Public_Offering.Core.Entities.Abstract;
using Public_Offering.Types.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Types.DTOs.CommentDtos
{
    public class CommentAddDto : IDto
    {
        public int UserId { get; set; }
        public int? ParentCommentId { get; set; }

        public int PublicOfferId { get; set; }
       
        public string CommentText { get; set; }
    }
}
