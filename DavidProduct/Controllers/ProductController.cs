using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DavidProduct.Models;

namespace DavidProduct.Controllers
{
    public class ProductController : Controller
    {
        private ShopContext context;
        public ProductController(ShopContext ctx)
        {
            context = ctx;
        }


        public IActionResult Index()
        {
            return RedirectToAction("List", "Products");
        }


       public IActionResult Details(int id)
        {
            var categories = context.Categories.OrderBy(c => c.CategoryID).ToList();

            Product product = context.Products.Find(id);

            var categoryName = "";
            foreach(var category in categories)
            {
                if (category.CategoryID == product.CategoryID)
                    categoryName = category.Name;
            }


            string imagefileName = product.Code + "-m.jpg";
            ViewBag.CategoryName = categoryName;
            ViewBag.Imagefilename = imagefileName;
            return View(product);
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            var categories = context.Categories.OrderBy(c => c.CategoryID).ToList();

            List<Product> products;
            if (id == "All")
                products = context.Products.OrderBy(p => p.ProductID).ToList();
            else if (id == "specials")
                products = context.Products.Where(p => p.Price < 5.0M).OrderBy(p => p.ProductID).ToList();
            else
                products = context.Products.Where(p => p.Category.Name == id).OrderBy(p => p.ProductID).ToList();


            var model = new ProductListViewModel
            {
                Categories = categories,
                Products = products,
                SelectedCategory = id
            };

           
                    

            return View(model);
        }

        
    }
}
