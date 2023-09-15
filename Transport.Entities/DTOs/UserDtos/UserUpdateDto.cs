﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.UserDtos
{
    public class UserUpdateDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }



        public string Email { get; set; }

        public bool Status { get; set; }

        public bool Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
