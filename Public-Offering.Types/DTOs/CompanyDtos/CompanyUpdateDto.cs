using Public_Offering.Core.Entities.Abstract;

namespace Public_Offering.Types.DTOs.CompanyDtos
{
    public class CompanyUpdateDto : IDto
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
