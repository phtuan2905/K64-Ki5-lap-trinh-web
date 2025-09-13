    using System.Diagnostics;
using LTW_Day04Lab_TH.Models;
using Microsoft.AspNetCore.Mvc;

namespace LTW_Day04Lab_TH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
