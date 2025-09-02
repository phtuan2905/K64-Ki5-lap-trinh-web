using System.Diagnostics;
using LTW_Day03Lab_BTTL.Models;
using Microsoft.AspNetCore.Mvc;

namespace LTW_Day03Lab_BTTL.Controllers
{
    public class HomeController : Controller
    {
        protected Product product = new Product();

        public IActionResult Index()
        {
            var products = product.GetProductList();
            return View(products);
        }
    }
}
