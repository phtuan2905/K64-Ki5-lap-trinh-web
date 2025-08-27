using Microsoft.AspNetCore.Mvc;

namespace LTW_Day02Lab.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowMessage(string msg)
        {
            ViewData["msg"] = msg;
            return View();
        }
    }
}
