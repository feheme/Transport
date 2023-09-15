using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.VehicleDtos
{
    public class VehicleDetailDto : IDto
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string VehicleType { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }


    }
}
