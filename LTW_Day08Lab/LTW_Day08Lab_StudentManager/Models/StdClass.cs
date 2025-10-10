using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTW_Day08Lab_StudentManager.Models
{
    [Table("StdClass")]
    public class StdClass
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên lớp không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
    }
}
