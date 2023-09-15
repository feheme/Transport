using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete;

namespace Transport.Entities.Concrete
{
    public class Company : AuditableEntity
    {

        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public List<Team> Teams { get; set; }

    }
}
