using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Public_Offering.Business.Abstract;

namespace PublicOffering.WebApi.Controllers.Areas.Admin
{
    [Route("api/[Area]7[controller]")]
    [ApiController]
    public class PublicOffersController : ControllerBase
    {
        IPublicOfferService _publicOfferService;

        public PublicOffersController(IPublicOfferService publicOfferService)
        {
            _publicOfferService = publicOfferService;
        }
    }
}
