using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.MessageDtos
{
    public class MessageDetailDto : IDto
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int TeamId { get; set; }
        public string TeamName { get; set; }


    }
}
