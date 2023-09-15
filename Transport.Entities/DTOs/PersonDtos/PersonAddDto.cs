using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.PersonDtos
{
    public class PersonAddDto : IDto
    {
        public string PersonName { get; set; }
        public int TeamId { get; set; }
    }
}
