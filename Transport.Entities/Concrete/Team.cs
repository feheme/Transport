using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete;

namespace Transport.Entities.Concrete
{
    public class Team : AuditableEntity
    {

        public string TeamName { get; set; }
        public string TransportationTask { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Person> Persons { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public ICollection<Reservation> Reservations { get; set; } // One team can be assigned to many reservations.

    }
}
