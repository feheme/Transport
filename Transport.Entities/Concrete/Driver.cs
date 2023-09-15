using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete;

namespace Transport.Entities.Concrete
{
    public class Driver : AuditableEntity
    {
        
        public string DriverName { get; set; }
        public string LicenseType { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        
    }
}
