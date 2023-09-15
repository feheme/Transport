using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete.Auth;
using Transport.Core.Utilities.Results;
using Transport.Entities.DTOs.UserDtos;

namespace Transport.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);

        Task<IDataResult<IEnumerable<UserDetailDto>>> GetListAsync(Expression<Func<User, bool>> filter = null);
        Task<IDataResult<UserDto>> GetAsync(Expression<Func<User, bool>> filter);

        Task<IDataResult<UserDto>> GetByIdAsync(int id);

        Task<IDataResult<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);

    }
}
