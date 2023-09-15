using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.DriverDtos
{
    public class DriverUpdateDto : IDto
    {
        public int Id { get; set; }
        public string DriverName { get; set; }
        public string LicenseType { get; set; }
        public int TeamId { get; set; }
    }
}
