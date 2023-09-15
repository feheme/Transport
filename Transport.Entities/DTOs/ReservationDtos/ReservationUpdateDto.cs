using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.ReservationDtos
{
    public class ReservationUpdateDto : IDto
    {
        public int Id { get; set; }
        public string? ReservationType { get; set; }
        public string? ReservationDetails { get; set; }
        public DateTime? ReservationDate { get; set; }

        public int UserId { get; set; }
        public int TeamId { get; set; }
    }
}
