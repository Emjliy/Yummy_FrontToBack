using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yummy_FrontToBack.DAL;
using Yummy_FrontToBack.ViewModels;

namespace Yummy_FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController

        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM home = new HomeVM
            {
                Products = _context.Products.Include(p => p.ProductImages).Include(p => p.ProductCategories).ThenInclude(c => c.Categories)
                .Where(p => !p.IsDeleted && p.ProductImages.Any(pi => pi.IsMain)).Take(6).ToList(),
                Categories = _context.Categories.Where(c => !c.IsDeleted).ToList(),
            };
            return View(home);
        }

        // GET: HomeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: HomeController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: HomeController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: HomeController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: HomeController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: HomeController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: HomeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
