using Microsoft.AspNetCore.Mvc.Rendering;

namespace LTW_Day03Lab.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int AuthorId { get; set; }
		public int GenreId { get; set; }
		public string Image {  get; set; }
		public float Price { get; set; }
		public int TotalPage { get; set; }
		public string Sumary { get; set; }

		public List<Book> GetBookList()
		{
			List<Book> books = new List<Book>()
			{
				new Book()
				{
					Id = 1,
					Title = "Truyện Kiều",
					AuthorId = 1,
					GenreId = 1,
					Image = "/images/products/truyen_kieu.webp",
					Price = 100000,
					TotalPage = 480,
					Sumary = "",
				},
				new Book()
				{
					Id = 2,
					Title = "Chí Phèo",
					AuthorId = 2,
					GenreId = 2,
					Image = "/images/products/chi_pheo.jpg",
					Price = 210000,
					TotalPage = 300,
					Sumary = "",
				},
				new Book()
				{
					Id = 3,
					Title = "Dế Mèn Phiêu Lưu Ký",
					AuthorId = 3,
					GenreId = 3,
					Image = "/images/products/de_men.jpg",
					Price = 95000,
					TotalPage = 52,
					Sumary = "",
				},
			};

			return books;
		}

		public Book GetBookById(int id)
		{
			Book book = GetBookList().Find(x => x.Id == id);
			return book;
		}

		public List<SelectListItem> Authors { get; } = new List<SelectListItem>()
		{
			new SelectListItem {Value = "1", Text = "Nguyễn Du"},
			new SelectListItem {Value = "2", Text = "Nam Cao"},
			new SelectListItem {Value = "3", Text = "Tô Hoài"},
		};

		public List<SelectListItem> Genres { get; } = new List<SelectListItem>()
		{
			new SelectListItem {Value = "1", Text = "Văn học trung đại"},
			new SelectListItem {Value = "2", Text = "Văn học hiện thực"},
			new SelectListItem {Value = "3", Text = "Văn học thiếu nhi"},
		};
	}
}
