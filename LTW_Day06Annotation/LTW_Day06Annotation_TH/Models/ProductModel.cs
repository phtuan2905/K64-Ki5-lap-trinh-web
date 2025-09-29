using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LTW_Day06Annotation_TH.Models
{
    public class ProductModel
    { 
        [
            Key,
            Required(ErrorMessage = "Mã sản phẩm ko được để trống")
        ]
        public int Id { get; set; }
        [
            Display(Name = "Tên sản phẩm"),
            Required(ErrorMessage = "Tên sản phẩm ko được để trống"),
            MinLength(6, ErrorMessage = "Tên sản phẩm tối thiểu 6 ký tự"),
            MaxLength(150, ErrorMessage = "Tên sản phẩm tối đa 150 ký tự")
        ]
        public string Name { get; set; }
        [
            Display(Name = "Ảnh sản phẩm"),
            Required(ErrorMessage = "Ảnh sản phẩm ko được để trống")
        ]
        public string Image { get; set; }
        [
            Display(Name = "Giá trị sản phẩm"),
            Required(ErrorMessage = "Giá trị sản phẩm ko được để trống"),
            Range(100000, float.MaxValue, ErrorMessage = "Giá trị sản phẩm phải từ 1000 trở lên"),
			DataType(DataType.Currency, ErrorMessage = "Giá trị sản phẩm ko hợp lệ"),
		]
        public float Price { get; set; }
        [
            Display(Name = "Giá trị khuyến mại sản phẩm"),
            Required(ErrorMessage = "Giá trị khuyến mại sản phẩm ko được để trống"),
            DataType(DataType.Currency, ErrorMessage = "Giá trị khuyến mại sản phẩm ko hợp lệ"),
			Remote(action: "SalePriceRange", controller: "Product", AdditionalFields = nameof(Price))
		]
        public float SalePrice { get; set; }
        [
            Display(Name = "Mô tả sản phẩm"),
            Required(ErrorMessage = "Mô tả sản phẩm ko được để trống"),
            StringLength(1500, ErrorMessage = "Mô tả sản phẩm tối đa 1500 ký tự"),
			Remote(action: "DescriptionValidate", controller: "Product")
		]
        public string Description { get; set; }
        [
            Display(Name = "Danh mục của sản phẩm"),
            Required(ErrorMessage = "Danh mục của sản phẩm ko được để trống")
        ]
        public int CategoryId { get; set; }

        public ProductModel() { }

        public ProductModel(int id, string name, string image, float price, float salePrice, string description, int categoryId)
        {
            Id = id;
            Name = name;
            Image = image;
            Price = price;
            SalePrice = salePrice;
            Description = description;
			CategoryId = categoryId;

		}
    }
}
