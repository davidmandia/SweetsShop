using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DavidProduct.Models;
using Microsoft.AspNetCore.Mvc;

namespace DavidProduct.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ShopContext context;

        public CategoryController(ShopContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Category");
        }

        [Route("[area]/Categories/{id?}")]
        public IActionResult List()
        {
            var categories = context.Categories.OrderBy(c => c.CategoryID).ToList();
            return View(categories);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddUpdate", new Category());
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            var category = context.Categories.Find(id);
            return View("AddUpdate", category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                if(category.CategoryID == 0)
                {
                    context.Categories.Add(category);
                }
                else
                {
                    context.Categories.Update(category);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Category");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate");
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            return View(category);

        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("List", "Category");
        }
    }
}
