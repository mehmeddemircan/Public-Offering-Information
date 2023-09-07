using AutoMapper;
using Public_Offering.Business.Abstract;
using Public_Offering.Business.Constants;
using Public_Offering.Core.Utilities.Results;
using Public_Offering.DataAccess.Abstract;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        ICompanyRepository _companyRepository;
        IMapper _mapper;
        public CompanyManager(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(CompanyAddDto entity)
        {
            var newCompany = _mapper.Map<Company>(entity);

            await _companyRepository.AddAsync(newCompany);


            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _companyRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<CompanyDetailDto>> GetAsync(Expression<Func<Company, bool>> filter)
        {
            var company = await _companyRepository.GetAsync(filter);
            if (company != null)
            {
                var companyDetailDto = _mapper.Map<CompanyDetailDto>(company);
                return new SuccessDataResult<CompanyDetailDto>(companyDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<CompanyDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<CompanyDetailDto>> GetByIdAsync(int id)
        {
            var company = await _companyRepository.GetAsync(x => x.Id == id);
            if (company != null)
            {
                var companyDetailDto = _mapper.Map<CompanyDetailDto>(company);
                return new SuccessDataResult<CompanyDetailDto>(companyDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<CompanyDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<CompaniesDto>>> GetListAsync(Expression<Func<Company, bool>> filter = null)
        {
            if (filter == null)
            {
                // Exception 
                //throw new UnauthorizedAccessException("UnAuthorized"); 
                var response = await _companyRepository.GetListAsync();
                var responseDetailDto = _mapper.Map<IEnumerable<CompaniesDto>>(response);
                return new SuccessDataResult<IEnumerable<CompaniesDto>>(responseDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _companyRepository.GetListAsync(filter);
                var responseDetailDto = _mapper.Map<IEnumerable<CompaniesDto>>(response);
                return new SuccessDataResult<IEnumerable<CompaniesDto>>(responseDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<CompanyUpdateDto>> UpdateAsync(CompanyUpdateDto companyUpdateDto)
        {
            var getCompany = await _companyRepository.GetAsync(x => x.Id == companyUpdateDto.Id);

            var company = _mapper.Map<Company>(companyUpdateDto);


            company.UpdatedDate = DateTime.Now;
            company.UpdatedBy = 1;


            var companyUpdate = await _companyRepository.UpdateAsync(company);
            var resultUpdateDto = _mapper.Map<CompanyUpdateDto>(companyUpdate);

            return new SuccessDataResult<CompanyUpdateDto>(resultUpdateDto, Messages.Updated);
        }
    }
}
