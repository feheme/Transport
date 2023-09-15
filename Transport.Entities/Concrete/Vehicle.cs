using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete;

namespace Transport.Entities.Concrete
{
    public class Vehicle : AuditableEntity
    {

        public string LicensePlate { get; set; }
        public string VehicleType { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
       
    }
}
