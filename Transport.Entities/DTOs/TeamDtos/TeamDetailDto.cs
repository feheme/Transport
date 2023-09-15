using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.TeamDtos
{
    public class TeamDetailDto : IDto
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TransportationTask { get; set; }
        public int CompanyId { get; set; }
        public int CompanyName { get; set; }
    }
}
