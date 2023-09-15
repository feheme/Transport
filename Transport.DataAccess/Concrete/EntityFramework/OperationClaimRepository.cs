using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.DataAccess.EntityFramework;
using Transport.Core.Entities.Concrete.Auth;
using Transport.DataAccess.Abstract;
using Transport.DataAccess.Concrete.Contexts;

namespace Transport.DataAccess.Concrete.EntityFramework
{
    public class OperationClaimRepository : EfBaseRepository<OperationClaim, ApplicationDbContext>, IOperationClaimRepository
    {
    }
}
