using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LTW_Day08Lab_TH.Models
{
    [Table("Banner")]
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Image { get; set; }

        public byte Status { get; set; }

        [StringLength(100, ErrorMessage = "Nội dung mô tả giới hạn 1000 ký tự")]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
