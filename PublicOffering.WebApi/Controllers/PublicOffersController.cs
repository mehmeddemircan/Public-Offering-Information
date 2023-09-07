using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Public_Offering.Business.Abstract;
using Public_Offering.Types.DTOs.PublicOfferDtos;

namespace PublicOffering.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicOffersController : ControllerBase
    {
        IPublicOfferService _publicOfferService;
        public PublicOffersController(IPublicOfferService publicOfferService)
        {
            _publicOfferService = publicOfferService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetAllPublicOffer()
        {
            var result = await _publicOfferService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddNewPublicOffer(PublicOfferAddDto publicOfferAddDto)
        {
            var result = await _publicOfferService.AddAsync(publicOfferAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpGet]
        [Route("[action]/{publicOfferId:int}")]
        public async Task<IActionResult> GetPublicOfferById(int publicOfferId)
        {
            var result = await _publicOfferService.GetByIdAsync(publicOfferId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }




        [HttpDelete]
        [Route("[action]/{publicOfferId:int}")]
        public async Task<IActionResult> DeletePublicOffer(int publicOfferId)
        {
            var result = await _publicOfferService.DeleteAsync(publicOfferId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdatePublicOffer([FromForm] PublicOfferUpdateDto publicOfferUpdateDto)
        {
            var result = await _publicOfferService.UpdateAsync(publicOfferUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
