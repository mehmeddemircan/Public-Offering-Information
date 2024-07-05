using Public_Offering.Core.DataAccess.EntityFramework;
using Public_Offering.DataAccess.Abstract;
using Public_Offering.DataAccess.Contexts;
using Public_Offering.Types.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.DataAccess.Concrete.EntityFramework
{
    public class CommentRepository :EfBaseRepository<Comment,ApplicationDbContext>, ICommentRepository
    {
    }
}
