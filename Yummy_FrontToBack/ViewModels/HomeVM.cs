using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yummy_FrontToBack.Models;

namespace Yummy_FrontToBack.ViewModels
{
    public class HomeVM
    {
        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Category> Categories { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
