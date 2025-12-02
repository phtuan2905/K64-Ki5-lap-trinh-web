using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PhamMinhTuan_231230946_Lan6.Models;

namespace PhamMinhTuan_231230946_Lan6.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
    {
        private PmtBookStoreDbContext db;

        public BookController(PmtBookStoreDbContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var books = db.Books.Where(b => b.Price >= 100).ToList();
            return View("Index", books);
        }

        [HttpGet("Filter")]
        public IActionResult Filter(int cid)
        {
            var books = db.Books.Where(b => b.Price >= 100 && b.CategoryId == cid).ToList();
            return PartialView("FilterTable", books);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.Publishers = new SelectList(db.Publishers.ToList(), "PublisherId", "PublisherName");
            return View("Create");
        }

        [HttpPost("Ceate")]
        public IActionResult Create(Book book)
        {
            var newId = "P";

            if (db.Books.Count() == 0)
            {
                newId = "P0";
            }
            else
            {
                string lastId = db.Books.OrderBy(b => b.BookId).Last().BookId;

                int lastIdNumber = int.Parse(lastId.Substring(1));

                int newIdNumber = lastIdNumber + 1;

                newId += newIdNumber.ToString();
            }

            book.BookId = newId;
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}