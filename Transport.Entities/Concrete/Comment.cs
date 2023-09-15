using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete;
using Transport.Core.Entities.Concrete.Auth;

namespace Transport.Entities.Concrete
{
    public class Comment : AuditableEntity
    {

        public string Content { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
