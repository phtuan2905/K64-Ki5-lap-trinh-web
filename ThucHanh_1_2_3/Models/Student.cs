using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThucHanh_1_2_3.Models
{
    public class Student
    {
        public int Id {get; set;}
        [Required]
        [StringLength(maximumLength: 100)]
        public string Name {get; set;}
        [Required]
        public string Email {get; set;}
        [Required]
        public string Password {get; set;}
        [Required]
        public Branch? Branch {get; set;}
        [Required]
        public Gender? Gender {get; set;}
        [Required]
        public bool IsRegular {get; set;}
        public string Address {get; set;}
        [Required]
        public DateOnly? DateOfBirth {get; set;}
    }
}