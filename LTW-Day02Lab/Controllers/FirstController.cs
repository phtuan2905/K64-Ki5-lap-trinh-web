using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace LTW_Day02Lab.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowNumber(int number)
        {
            ViewData["number"] = number;
            return View();
        }
    }
}
