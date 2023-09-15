using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete.Auth;
using Transport.Core.Utilities.Results;
using Transport.Entities.DTOs.UserOperationClaimDtos;

namespace Transport.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        Task<IResult> AddAsync(UserOperationClaimAddDto entity);


        Task<IDataResult<IEnumerable<UserOperationClaimDetailDto>>> GetListAsync(Expression<Func<UserOperationClaim, bool>> filter = null);
        Task<IDataResult<UserOperationClaimDetailDto>> GetAsync(Expression<Func<UserOperationClaim, bool>> filter);

        Task<IDataResult<UserOperationClaimDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<UserOperationClaimUpdateDto>> UpdateAsync(UserOperationClaimUpdateDto userOperationClaimUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
