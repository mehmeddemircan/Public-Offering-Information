using Public_Offering.Core.DataAccess;
using Public_Offering.Types.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.DataAccess.Abstract
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
    }
}
