using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yummy_FrontToBack.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
