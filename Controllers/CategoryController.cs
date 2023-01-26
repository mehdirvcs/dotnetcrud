using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Data;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDB _db;
        public CategoryController(ApplicationDB db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> cat = _db.Categories;
            return View(cat);
        }
        
        //GET
        public IActionResult Create()
        {
            //IEnumerable<Category> cat = _db.Categories;
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Display error cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Added Successfully!";
                //IEnumerable<Category> cat = _db.Categories;
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var CategorybyId = _db.Categories.Find(id);
            //var CategorybyId = _db.Categories.SingleOrDefault(u => u.id==id);
            //var CategorybyId = _db.Categories.FirstOrDefault(u => u.id == id);
            if (CategorybyId == null)
            {
                return NotFound();
            }
            return View(CategorybyId);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Display error cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully!";
                //IEnumerable<Category> cat = _db.Categories;
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategorybyId = _db.Categories.Find(id);
            //var CategorybyId = _db.Categories.SingleOrDefault(u => u.id==id);
            //var CategorybyId = _db.Categories.FirstOrDefault(u => u.id == id);
            if (CategorybyId == null)
            {
                return NotFound();
            }
            return View(CategorybyId);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var cat = _db.Categories.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(cat);
            _db.SaveChanges();
            //IEnumerable<Category> cat = _db.Categories;
            TempData["success"] = "Category Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
