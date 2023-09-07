using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Core.Entities.Concrete.Auth
{
    public class OperationClaim : AuditableEntity
    {

        public string Name { get; set; }

        public virtual ICollection<UserOperationClaim>? UserRoles { get; set; }
    }
}
