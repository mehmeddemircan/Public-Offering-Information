using Public_Offering.Core.Utilities.Results;
using Public_Offering.Types.Concrete;
using Public_Offering.Types.DTOs.PublicOfferDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Abstract
{
    public interface IPublicOfferService 
    {
        Task<IResult> AddAsync(PublicOfferAddDto entity);


        Task<IDataResult<IEnumerable<PublicOffersDto>>> GetListAsync(Expression<Func<PublicOffer, bool>> filter = null);
        Task<IDataResult<PublicOfferDetailDto>> GetAsync(Expression<Func<PublicOffer, bool>> filter);

        Task<IDataResult<PublicOfferDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<PublicOfferUpdateDto>> UpdateAsync(PublicOfferUpdateDto publicOfferUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
