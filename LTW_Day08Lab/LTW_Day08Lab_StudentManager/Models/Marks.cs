using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LTW_Day08Lab_StudentManager.Models
{
    [Table("Marks")]
    public class Marks
    {
        [Required(ErrorMessage = "Mã môn học không được để trống")]
        public int SubjectId {  get; set; }

        [Required(ErrorMessage = "Mã học sinh không được để trống")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Điểm không được để trống")]
        public float Score { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public Subjects Subjects { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Students { get; set; }
    }
}
