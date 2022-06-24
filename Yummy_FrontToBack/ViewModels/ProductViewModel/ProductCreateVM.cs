using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Yummy_FrontToBack.Models;

namespace Yummy_FrontToBack.ViewModels
{
    public class ProductCreateVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
    }
}
