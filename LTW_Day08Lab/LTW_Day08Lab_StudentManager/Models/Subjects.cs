using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LTW_Day08Lab_StudentManager.Models
{
    [Table("Subjects")]
    [Index(nameof(SubjectName), IsUnique = true)]
    public class Subjects
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên môn học không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string SubjectName { get; set; }
    }
}
