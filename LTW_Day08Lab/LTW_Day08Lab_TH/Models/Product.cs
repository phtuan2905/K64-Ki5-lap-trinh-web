using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTW_Day08Lab_TH.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Image {  get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        public float Price { get; set; }

        public float SalePrice { get; set; }
        
        public byte Status { get; set; }

        [StringLength(100, ErrorMessage = "Nội dung mô tả giới hạn 1000 ký tự")]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Danh mục sản phẩm không được để trống")]
        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }

        public Category Category { get; set; }
    }
}
