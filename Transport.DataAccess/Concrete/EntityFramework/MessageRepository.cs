using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.DataAccess.EntityFramework;
using Transport.DataAccess.Abstract;
using Transport.DataAccess.Concrete.Contexts;
using Transport.Entities.Concrete;

namespace Transport.DataAccess.Concrete.EntityFramework
{
    public class MessageRepository : EfBaseRepository<Message, ApplicationDbContext>, IMessageRepository
    {
    }
}
