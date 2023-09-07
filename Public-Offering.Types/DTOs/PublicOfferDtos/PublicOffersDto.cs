using Public_Offering.Core.Entities.Abstract;
using Public_Offering.Types.Enums;

namespace Public_Offering.Types.DTOs.PublicOfferDtos
{
    public class PublicOffersDto : IDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
        public int TotalLot { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PublicOfferStatus PublicOfferStatu { get; set; }
        public bool IsPublicOffer { get; set; } = false;
    }
}
