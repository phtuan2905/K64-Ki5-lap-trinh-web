using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTW_Day09Lab_CodeFirst.Models
{
    [Table("TvcSanPham")]
    public class TvcSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long tvcID { get; set; }


        [Display(Name = "Mã sản phẩm")]
        [Required]
        [StringLength(10)]
        public string tvcMaSanPham { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string tvcTenSanPham { get; set; }

        [Display(Name = "Hình ảnh")]
        public string tvcHinhAnh { get; set; }

        [Display(Name = "Số lượng")]
        public int tvcSoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal tvcDonGia { get; set; }

        public long tvcLoaiSanPhamID { get; set; }

        [ForeignKey(nameof(tvcLoaiSanPhamID))]
        public TvcLoaiSanPham TvcLoaiSanPham { get; set; }
    }
}
