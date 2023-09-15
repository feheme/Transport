using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Business.Abstract;
using Transport.Business.Constants;
using Transport.Core.Entities.Concrete.Auth;
using Transport.Core.Utilities.Results;
using Transport.DataAccess.Abstract;

namespace Transport.Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimRepository _operationClaimRepository;

        public OperationClaimManager(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<IResult> AddAsync(OperationClaim entity)
        {
            await _operationClaimRepository.AddAsync(entity);

            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _operationClaimRepository.DeleteAsync(id);

            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        //[LogAspect(typeof(FileLogger))]

        public async Task<IDataResult<IEnumerable<OperationClaim>>> GetAllAsync(Expression<Func<OperationClaim, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _operationClaimRepository.GetListAsync();


                return new SuccessDataResult<IEnumerable<OperationClaim>>(response, Messages.Listed);
            }
            else
            {
                var response = await _operationClaimRepository.GetListAsync(filter);


                return new SuccessDataResult<IEnumerable<OperationClaim>>(response, Messages.Listed);
            }
        }

        public async Task<IDataResult<OperationClaim>> GetSingleAsync(Expression<Func<OperationClaim, bool>> filter)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(filter);

            if (operationClaim != null)
            {


                return new SuccessDataResult<OperationClaim>(operationClaim, Messages.Listed);
            }
            return new ErrorDataResult<OperationClaim>(null, Messages.NotListed);
        }

        public async Task<IResult> UpdateAsync(OperationClaim entity)
        {
            await _operationClaimRepository.UpdateAsync(entity);

            return new SuccessResult(Messages.Updated);
        }
    }
}
