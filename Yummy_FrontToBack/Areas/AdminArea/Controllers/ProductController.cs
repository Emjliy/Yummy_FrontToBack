using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yummy_FrontToBack.DAL;
using Yummy_FrontToBack.Helpers;
using Yummy_FrontToBack.Models;
using Yummy_FrontToBack.ViewModels;

namespace Yummy_FrontToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]

    public class ProductController : Controller
    {
        private AppDbContext _context { get; set; }
        public IWebHostEnvironment _env { get; }
        private IEnumerable<Product> products;
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env=env;
            products = _context.Products.Include(p => p.ProductImages)
            .Where(p => !p.IsDeleted && p.ProductImages.Any(pi =>pi .IsMain)).Take(6).ToList();
        }
        public IActionResult Index()
        {
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM productVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //bool isExist = _context.Products.Any(p => p.Title.ToLower().Trim() == productVM.Title.ToLower().Trim());
            //if (isExist)
            //{
            //    ModelState.AddModelError("Title", "This product is already exist.");
            //    View();
            //}
            ProductCreateVM newProduct = new ProductCreateVM
            {
                Title = productVM.Title,
                Description = productVM.Description,
            };
            string url = await productVM.Photo.SaveFileAsync(_env.WebRootPath, "img");
            ProductImage productImages = new ProductImage
            {
                URL = url
            };
            List<ProductImage> productsUrl = new List<ProductImage>();
            productsUrl.Add(productImages);
            newProduct.ProductImages = productsUrl; 
            await _context.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var dbProduct = _context.Products.Find(id);
            if (dbProduct == null)
            {
                return NotFound();
            }
            var path = Helper.GetPath(_env.WebRootPath, "img", dbProduct.ProductImages.FirstOrDefault().URL);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            dbProduct.IsDeleted = true;
            //_context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
