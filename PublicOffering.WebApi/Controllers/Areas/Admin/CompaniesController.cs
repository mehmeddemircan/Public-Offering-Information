using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Public_Offering.Business.Abstract;

namespace PublicOffering.WebApi.Controllers.Areas.Admin
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        ICompanyService _companyService;
         
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
    }
}
