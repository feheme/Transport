using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.DataAccess;
using Transport.Core.Entities.Concrete.Auth;

namespace Transport.DataAccess.Abstract
{
    public interface IUserOperationClaimRepository : IBaseRepository<UserOperationClaim>
    {
    }
}
