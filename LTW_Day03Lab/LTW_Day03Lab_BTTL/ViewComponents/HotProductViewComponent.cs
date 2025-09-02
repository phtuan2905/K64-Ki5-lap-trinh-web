using LTW_Day03Lab_BTTL.Models;
using Microsoft.AspNetCore.Mvc;

namespace LTW_Day03Lab_BTTL.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        protected Product product = new Product();

        public IViewComponentResult Invoke()
        {
            var products = product.GetProductList();
            return View(products);
        }
    }
}
