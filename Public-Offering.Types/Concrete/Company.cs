using Public_Offering.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Types.Concrete
{
    public class Company : AuditableEntity
    {
        public string CompanyCode { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
