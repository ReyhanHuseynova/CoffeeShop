﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Description { get; set; }
    }
}
