using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Quadra.Data;
using Product_Quadra.Models;

namespace Product_Quadra.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataBaseContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(DataBaseContext context, IWebHostEnvironment env)
        {
            _context = context;
            _hostEnvironment = env;
        }

        // GET: ProductAll
        public IActionResult Index()
        {
            var result = _context.Product.Where(it => true).ToList();
            return View(result);
        }

        // GET: ProductController/Details/
        public ActionResult Details(int id)
        {
            var item = _context.Product.Where(it => it.Id == id).FirstOrDefault();
            return View(item);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product data, IFormFile File)
        {
            try
            {
                // TODO: Add insert logic here
                if (File != null)
                {
                    //upload files to wwwroot
                    var fileName = Path.GetFileName(File.FileName);
                    var filePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", fileName);

                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        File.CopyToAsync(fileSteam);
                    }
                    var item = new Product
                    {
                        Id = 0,
                        Name = data.Name,
                        Imag = fileName,
                        Title = data.Title,
                        DateTimeNow = DateTime.Now.ToString("MM/dd/yyyy")
                    };
                    _context.Add(item);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/
        public ActionResult Edit(int id)
        {
            var item = _context.Product.Where(it => it.Id == id).FirstOrDefault();
            return View(item);
        }

        // POST: ProductController/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product data)
        {
            try
            {
                data.DateTimeNow = DateTime.Now.ToString("MM/dd/yyyy");
                _context.Product.Update(data);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/
        public ActionResult Delete(int id)
        {
            var item = _context.Product.Find(id);
            return View(item);
        }

        // POST: ProductController/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product data)
        {
            try
            {
                _context.Product.Remove(data);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
