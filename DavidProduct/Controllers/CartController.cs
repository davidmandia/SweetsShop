using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DavidProduct.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(string id)
        {
            ViewBag.Productslug = id;
            return View();
        }
    }
}
