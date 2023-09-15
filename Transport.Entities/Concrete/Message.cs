﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete;
using Transport.Core.Entities.Concrete.Auth;

namespace Transport.Entities.Concrete
{
    public class Message : AuditableEntity
    {
        public string Content { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
