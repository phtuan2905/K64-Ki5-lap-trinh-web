﻿using LTW_Day03Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace LTW_Day03Lab.Controllers
{
	public class BookController : Controller
	{
		protected Book book = new Book();
		public IActionResult Index()
		{
			ViewBag.authors = book.Authors;
			ViewBag.genres = book.Genres;
			var books = book.GetBookList();
			return View(books);
		}

		public IActionResult Create()
		{
			ViewBag.authors = book.Authors;
			ViewBag.genres = book.Genres;
			Book model = new Book();
			return View(model);
		}

		public IActionResult Edit(int id)
		{
			ViewBag.authors = book.Authors;
			ViewBag.genres = book.Genres;
			var model = book.GetBookById(book.Id);
			return View(model);
		}

		public PartialViewResult PopularBook()
		{
			var books = book.GetBookList();
			return PartialView(books);
		}
	}
}
