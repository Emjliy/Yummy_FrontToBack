using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yummy_FrontToBack.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int ProductID { get; set; }
        public Product Products { get; set; }
        public Category Categories { get; set; }
    }
}
