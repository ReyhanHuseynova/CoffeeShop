﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Image { get; set; }
        public string Icons { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public bool IsDeactive { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
