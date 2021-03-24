using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DavidProduct.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DavidProduct.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        private ShopContext context;
        private List<Category> categories;

        public ProductController(ShopContext ctx)
        {
            context = ctx;
            categories = context.Categories.OrderBy(c => c.CategoryID).ToList();
        }


        public IActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<Product> products;
            if (id == "All")
            {
                products = context.Products.OrderBy(p => p.ProductID).ToList();
            }
            else
            {
                products = context.Products.Where(p => p.Category.Name == id).ToList();
            }

            var model = new ProductListViewModel
            {
                Categories = categories,
                Products = products,
                SelectedCategory = id
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult Add()
        {
            var product = new Product();
            product.Category = context.Categories.Find(1);

            ViewBag.Action = "Add";
            ViewBag.Categories = categories;
            return View("AddUpdate", product);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductID == id);

            ViewBag.Action = "Update";
            ViewBag.Categories = categories;
            return View("AddUpdate", product);
        }


        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                var userMessage = "";
                if(product.ProductID == 0)
                {
                    context.Products.Add(product);
                    userMessage = "You just added a product " + product.Name;
                }
                else
                {
                    context.Products.Update(product);
                    userMessage = "You just Updated a product " + product.Name;
                }
                context.SaveChanges();
                TempData["UserMessage"] = userMessage;
                return RedirectToAction("List", "Product");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                //passing the model
                return View("AddUpdate", product);
            }

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.ProductID == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List", "Product");
        }


    }
}
