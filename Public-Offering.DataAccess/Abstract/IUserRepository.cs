using Public_Offering.Core.DataAccess;
using Public_Offering.Core.Entities.Concrete.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.DataAccess.Abstract
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
