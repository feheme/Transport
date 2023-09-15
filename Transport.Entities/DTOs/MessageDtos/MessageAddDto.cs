using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;
using Transport.Core.Entities.Concrete.Auth;
using Transport.Entities.Concrete;

namespace Transport.Entities.DTOs.MessageDtos
{
    public class MessageAddDto : IDto
    {
        public string Content { get; set; }

        public int UserId { get; set; }

        public int TeamId { get; set; }

    }
}
