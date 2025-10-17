using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LTW_Day09Lab_CodeFirst.Models
{
    [Table("TvcLoaiSanPham")]
    [Index(nameof(tvcMaLoai), IsUnique = true)]
    public class TvcLoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long tvcId { get; set; }

        [Display(Name = "Mã loại")]
        [StringLength(50)]
        public string tvcMaLoai { get; set; }

        [Display(Name = "Tên loại")]
        public string tvcTenLoai { get; set; }

        [Display(Name = "Trạng thái")]
        public bool tvcTrangThai { get; set; }

        public ICollection<TvcSanPham> tvcSanPhams { get; set; } = new List<TvcSanPham>();
    }
}
