﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.UserDtos
{
    public class UserAddDto : IDto
    {
        public string Username { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }

        public bool Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
