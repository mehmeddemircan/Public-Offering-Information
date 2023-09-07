using Public_Offering.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Types.DTOs.CompanyDtos
{
    public class CompaniesDto : IDto
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
