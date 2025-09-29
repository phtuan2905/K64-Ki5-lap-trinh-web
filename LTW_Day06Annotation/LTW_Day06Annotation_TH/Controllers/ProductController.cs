using LTW_Day06Annotation_TH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LTW_Day06Annotation_TH.Controllers
{
    public class ProductController : Controller
    {
        public static List<ProductModel> products = new List<ProductModel>()
        {
            new ProductModel(1, "Product 1", "/images/1/b5bd56c1aa4644a474a2e4972be27ef9e82e517e_full.jpg", 200000, 200, "Mô tả", 1),
        };

        public static List<CategoryModel> categories = new List<CategoryModel>()
        {
            new CategoryModel(1, "Category 1"),
        };

        // GET: ProductController
        public ActionResult Index()
        {
            ViewBag.Categories = categories;
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Categories = categories;
            ProductModel p = new ProductModel();
            foreach (ProductModel pro in products)
            {
                if (pro.Id == id)
                {
                    p = pro;
                    break;
                }
            }
            return View(p);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = categories;
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
			int id = int.Parse(collection["Id"]);
            string name = collection["Name"];
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", id.ToString());
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
			}
			var file = collection.Files["Image"];
			filePath = Path.Combine(filePath, file.FileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				file.CopyTo(stream);
			}
			string image = "/images/" + id.ToString() + "/" + file.FileName;
            float price = float.Parse(collection["Price"]);
            float salePrice = float.Parse(collection["SalePrice"]);
            string description = collection["Description"];
            int categoryId = int.Parse(collection["CategoryId"]);

            ProductModel newProduct = new ProductModel(id, name, image, price, salePrice, description, categoryId);
            products.Add(newProduct);

			return RedirectToAction("Index");
		}

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
		{
			ViewBag.Categories = categories;
            ProductModel p = new ProductModel();
            foreach (ProductModel pro in products)
            {
                if (pro.Id == id)
                {
                    p = pro;
                    break;
                }
            }
			return View(p);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
		{
			int newId = int.Parse(collection["Id"]);
			string name = collection["Name"];
            string image = "";
            if (collection.Files["NewImage"] != null)
            {

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", id.ToString());
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                var file = collection.Files["NewImage"];
                filePath = Path.Combine(filePath, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                image = "/images/" + id.ToString() + "/" + file.FileName;
            }
			float price = float.Parse(collection["Price"]);
			float salePrice = float.Parse(collection["SalePrice"]);
			string description = collection["Description"];
			int categoryId = int.Parse(collection["CategoryId"]);

			foreach (ProductModel pro in products)
			{
				if (pro.Id == id)
				{
					pro.Id = newId;
                    pro.Name = name;
                    if (image != "")
                    {
						System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + pro.Image);
						pro.Image = image;
					}
                    pro.Price = price;
                    pro.SalePrice = salePrice;
                    pro.Description = description;
                    pro.CategoryId = categoryId;
					break;
				}
			}
			return RedirectToAction("Index");
		}

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Categories = categories;
            ProductModel p = new ProductModel();
            foreach (ProductModel pro in products)
            {
                if (pro.Id == id)
                {
                    p = pro;
                    break;
                }
            }
            return View(p);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            System.IO.Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", id.ToString()), true);
            foreach (ProductModel pro in products)
            {
                if (pro.Id == id)
                {
                    products.Remove(pro);
                    break;
                }
            }
            return RedirectToAction("Index");
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult SalePriceRange(float salePrice, float price) 
        {
            if (salePrice < 0)
            {
                return Json("Khuyến mại ko được âm");
            }

            if (salePrice > (price / 100f) * 10f)
            {
                return Json("Khuyến mại ko được vượt quá 10% Giá trị sản phẩm");
            }

            return Json(true);
        }

        public IActionResult DescriptionValidate(string description)
        {
            List<string> badWords = new List<string>()
            {
                "die",
                "admin",
                "fack"
            };

            string badWordsText = "";

            foreach (var badWord in badWords)
            {
                if (description.Contains(badWord))
                {
					badWordsText += badWord + ",";
                }
            }

            if (badWordsText != "")
            {
                return Json("Mô tả sản phẩm ko được chứa các từ nhạy cảm: " +  badWordsText);
			}

			return Json(true);
		}

	}
}
