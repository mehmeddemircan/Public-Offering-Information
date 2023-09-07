using Public_Offering.Core.Entities.Abstract;
using Public_Offering.Types.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Types.DTOs.PublicOfferDtos
{
    public class PublicOfferAddDto : IDto
    {

        public int CompanyId { get; set; }
        public decimal Price { get; set; }
        public int TotalLot { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PublicOfferStatus PublicOfferStatu { get; set; } = PublicOfferStatus.NotPublicOfferNow;
        public bool IsPublicOffer { get; set; } = false;
    }
}
