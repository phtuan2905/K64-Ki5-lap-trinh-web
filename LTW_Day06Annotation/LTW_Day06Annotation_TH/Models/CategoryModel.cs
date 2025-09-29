using System.ComponentModel.DataAnnotations;

namespace LTW_Day06Annotation_TH.Models
{
    public class CategoryModel
    {

		[Key]
		public int Id { get; set; }
		[
			Display(Name = "Tên danh mục"),
			Required(ErrorMessage = "Tên danh mục ko được để trống"),
			MinLength(6, ErrorMessage = "Tên danh mục tối thiểu 6 ký tự"),
			MaxLength(150, ErrorMessage = "Tên danh mục tối đa 150 ký tự")
		]
		public string Name { get; set; }

		public CategoryModel(int id, string name) 
		{
			Id = id;
			Name = name;
		}
    }
}
