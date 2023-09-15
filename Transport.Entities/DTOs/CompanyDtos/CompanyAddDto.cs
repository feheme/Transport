﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.CompanyDtos
{
    public class CompanyAddDto : IDto
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
    }
}
