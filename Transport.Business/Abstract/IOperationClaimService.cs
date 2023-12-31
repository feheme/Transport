﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete.Auth;
using Transport.Core.Utilities.Results;

namespace Transport.Business.Abstract
{
    public interface IOperationClaimService
    {
        Task<IResult> AddAsync(OperationClaim entity);

        Task<IDataResult<IEnumerable<OperationClaim>>> GetAllAsync(Expression<Func<OperationClaim, bool>> filter = null);
        Task<IDataResult<OperationClaim>> GetSingleAsync(Expression<Func<OperationClaim, bool>> filter);
        Task<IResult> UpdateAsync(OperationClaim entity);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
