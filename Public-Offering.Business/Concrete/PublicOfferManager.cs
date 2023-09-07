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
        IPublicOfferRepository _companyRepository;
        IMapper _mapper;
        public PublicOfferManager(IPublicOfferRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(PublicOfferAddDto entity)
        {
            var newPublicOffer = _mapper.Map<PublicOffer>(entity);

            await _companyRepository.AddAsync(newPublicOffer);


            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _companyRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<PublicOfferDetailDto>> GetAsync(Expression<Func<PublicOffer, bool>> filter)
        {
            var company = await _companyRepository.GetAsync(filter);
            if (company != null)
            {
                var companyDetailDto = _mapper.Map<PublicOfferDetailDto>(company);
                return new SuccessDataResult<PublicOfferDetailDto>(companyDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<PublicOfferDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<PublicOfferDetailDto>> GetByIdAsync(int id)
        {
            var company = await _companyRepository.GetAsync(x => x.Id == id);
            if (company != null)
            {
                var companyDetailDto = _mapper.Map<PublicOfferDetailDto>(company);
                return new SuccessDataResult<PublicOfferDetailDto>(companyDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<PublicOfferDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<PublicOffersDto>>> GetListAsync(Expression<Func<PublicOffer, bool>> filter = null)
        {
            if (filter == null)
            {
                // Exception 
                //throw new UnauthorizedAccessException("UnAuthorized"); 
                var response = await _companyRepository.GetListAsync();
                var responseDetailDto = _mapper.Map<IEnumerable<PublicOffersDto>>(response);
                return new SuccessDataResult<IEnumerable<PublicOffersDto>>(responseDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _companyRepository.GetListAsync(filter);
                var responseDetailDto = _mapper.Map<IEnumerable<PublicOffersDto>>(response);
                return new SuccessDataResult<IEnumerable<PublicOffersDto>>(responseDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<PublicOfferUpdateDto>> UpdateAsync(PublicOfferUpdateDto companyUpdateDto)
        {
            var getPublicOffer = await _companyRepository.GetAsync(x => x.Id == companyUpdateDto.Id);

            var company = _mapper.Map<PublicOffer>(companyUpdateDto);


            company.UpdatedDate = DateTime.Now;
            company.UpdatedBy = 1;


            var companyUpdate = await _companyRepository.UpdateAsync(company);
            var resultUpdateDto = _mapper.Map<PublicOfferUpdateDto>(companyUpdate);

            return new SuccessDataResult<PublicOfferUpdateDto>(resultUpdateDto, Messages.Updated);
        }
    }
}
