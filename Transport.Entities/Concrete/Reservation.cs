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

        public string? ReservationType { get; set; } 
        public string? ReservationDetails { get; set; }
        //public DateTime? ReservationDate { get; set; }

       
        public int UserId { get; set; }
        public User? User { get; set; }

        
        public int TeamId { get; set; }
        public Team? Team { get; set; }


    }
}
