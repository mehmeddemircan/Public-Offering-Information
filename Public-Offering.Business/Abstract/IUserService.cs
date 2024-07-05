using Public_Offering.Core.Entities.Concrete.Auth;
using Public_Offering.Core.Utilities.Results;
using Public_Offering.Entity.DTOs.UsersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);

        Task<IDataResult<IEnumerable<UserDetailDto>>> GetListAsync(Expression<Func<User, bool>> filter = null);
        Task<IDataResult<UsersDto>> GetAsync(Expression<Func<User, bool>> filter);

        Task<IDataResult<UsersDto>> GetByIdAsync(int id);

        Task<IDataResult<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
