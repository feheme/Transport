using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete;
using Transport.Core.Entities.Concrete.Auth;

namespace Transport.Entities.Concrete
{
    public class Reservation : AuditableEntity
    {

        public string ReservationType { get; set; } // "Home Moving," "Office Moving," etc.
        public string ReservationDetails { get; set; }
        public DateTime ReservationDate { get; set; }

        // Information about the user who made the reservation.
        public int UserId { get; set; }
        public User User { get; set; }

        // Relationship for the team assigned to this reservation (one-to-many).
        public int TeamId { get; set; }
        public Team Team { get; set; }


    }
}
