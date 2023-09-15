using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.PersonDtos
{
    public class PersonUpdateDto : IDto
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public int TeamId { get; set; }
    }
}
