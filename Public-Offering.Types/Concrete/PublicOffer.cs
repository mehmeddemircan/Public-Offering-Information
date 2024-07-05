using Public_Offering.Core.Entities.Concrete;
using Public_Offering.Types.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Types.Concrete
{
    public class PublicOffer : AuditableEntity
    {
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public decimal Price { get; set; }
        public int TotalLot { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime  EndDate { get; set; }

        public PublicOfferStatus PublicOfferStatu { get; set; }

        public bool IsPublicOffer { get; set; } 

        public virtual ICollection<Comment>? Comments { get;}
    }
}
