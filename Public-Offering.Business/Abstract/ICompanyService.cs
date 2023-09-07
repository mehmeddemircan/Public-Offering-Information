using Public_Offering.Core.Utilities.Results;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Abstract
{
    public interface ICompanyService
    {
        Task<IResult> AddAsync(CompanyAddDto entity);


        Task<IDataResult<IEnumerable<CompaniesDto>>> GetListAsync(Expression<Func<Company, bool>> filter = null);
        Task<IDataResult<CompanyDetailDto>> GetAsync(Expression<Func<Company, bool>> filter);

        Task<IDataResult<CompanyDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<CompanyUpdateDto>> UpdateAsync(CompanyUpdateDto CompanyUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
