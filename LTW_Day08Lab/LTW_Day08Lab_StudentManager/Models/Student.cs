using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LTW_Day08Lab_StudentManager.Models
{
    [Table("Student")]
    [Index(nameof(StudentEmail), IsUnique = true)]
    [Index(nameof(StudentPhone), IsUnique = true)]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên học sinh không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Tên học sinh không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string StudentEmail { get; set; }

        [Required(ErrorMessage = "Số điện thoại học sinh không được để trống")]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string StudentPhone { get; set; }

        [Required(ErrorMessage = "Địa chỉ của học sinh không được để trống")]
        [StringLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string StudentAddress { get; set; }

        [Required(ErrorMessage = "Avatar của học sinh không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string StudentAvatar { get; set; }

        [Required(ErrorMessage = "Ngày sinh của học sinh không được để trống")]
        public DateOnly StudentBirthday { get; set; }

        [Required(ErrorMessage = "Mã lớp của học sinh không được để trống")]
        public int ClassId { get; set; }

        [ForeignKey(nameof(ClassId))]
        public StdClass StdClass { get; set; }
    }
}
