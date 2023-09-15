using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.DataAccess;
using Transport.Entities.Concrete;

namespace Transport.DataAccess.Abstract
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
    }
}
