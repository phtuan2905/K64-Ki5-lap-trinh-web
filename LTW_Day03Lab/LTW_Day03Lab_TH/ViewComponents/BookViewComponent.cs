using LTW_Day03Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace LTW_Day03Lab.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();
        public IViewComponentResult Invoke()
        {
            var books = book.GetBookList();
            return View(books);
        }
    }
}
