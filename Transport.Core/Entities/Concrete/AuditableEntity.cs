using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Core.Entities.Concrete
{
    public class AuditableEntity : BaseEntity, ICreatedEntity, IUpdatedEntity
    {

               

        public DateTime? CreatedDate { get; set; }        

        public DateTime? UpdatedDate { get; set; }
    }
}
