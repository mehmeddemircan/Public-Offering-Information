using AutoMapper;
using Public_Offering.Business.Abstract;
using Public_Offering.Business.Constants;
using Public_Offering.Core.Utilities.Results;
using Public_Offering.DataAccess.Abstract;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.PublicOfferDtos;
using Public_Offering.Types.DTOs.PublicOfferDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Concrete
{
    public class PublicOfferManager : IPublicOfferService
    {
        IPublicOfferRepository _publicOfferRepository;
        IMapper _mapper;
        public PublicOfferManager(IPublicOfferRepository publicOfferRepository, IMapper mapper)
        {
            _publicOfferRepository = publicOfferRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(PublicOfferAddDto entity)
        {
            var newPublicOffer = _mapper.Map<PublicOffer>(entity);

            await _publicOfferRepository.AddAsync(newPublicOffer);


            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _publicOfferRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<PublicOfferDetailDto>> GetAsync(Expression<Func<PublicOffer, bool>> filter)
        {
            var publicOffer = await _publicOfferRepository.GetAsync(filter);
            if (publicOffer != null)
            {
                var publicOfferDetailDto = _mapper.Map<PublicOfferDetailDto>(publicOffer);
                return new SuccessDataResult<PublicOfferDetailDto>(publicOfferDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<PublicOfferDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<PublicOfferDetailDto>> GetByIdAsync(int id)
        {
            var publicOffer = await _publicOfferRepository.GetAsync(x => x.Id == id);
            if (publicOffer != null)
            {
                var publicOfferDetailDto = _mapper.Map<PublicOfferDetailDto>(publicOffer);
                return new SuccessDataResult<PublicOfferDetailDto>(publicOfferDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<PublicOfferDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<PublicOffersDto>>> GetListAsync(Expression<Func<PublicOffer, bool>> filter = null)
        {
            if (filter == null)
            {
                // Exception 
                //throw new UnauthorizedAccessException("UnAuthorized"); 
                var response = await _publicOfferRepository.GetListAsync();
                var responseDetailDto = _mapper.Map<IEnumerable<PublicOffersDto>>(response);
                return new SuccessDataResult<IEnumerable<PublicOffersDto>>(responseDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _publicOfferRepository.GetListAsync(filter);
                var responseDetailDto = _mapper.Map<IEnumerable<PublicOffersDto>>(response);
                return new SuccessDataResult<IEnumerable<PublicOffersDto>>(responseDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<PublicOfferUpdateDto>> UpdateAsync(PublicOfferUpdateDto publicOfferUpdateDto)
        {
            var getPublicOffer = await _publicOfferRepository.GetAsync(x => x.Id == publicOfferUpdateDto.Id);

            var publicOffer = _mapper.Map<PublicOffer>(publicOfferUpdateDto);


            publicOffer.UpdatedDate = DateTime.Now;
            publicOffer.UpdatedBy = 1;


            var publicOfferUpdate = await _publicOfferRepository.UpdateAsync(publicOffer);
            var resultUpdateDto = _mapper.Map<PublicOfferUpdateDto>(publicOfferUpdate);

            return new SuccessDataResult<PublicOfferUpdateDto>(resultUpdateDto, Messages.Updated);
        }
    }
}
