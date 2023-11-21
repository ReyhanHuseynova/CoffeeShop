using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Menu
    {
        public int MenuID { get; set; }
        public string SubCategoryName { get; set; }
        public string Image { get; set; }
        public string Icons { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsDeactive { get; set; }

    }
}
