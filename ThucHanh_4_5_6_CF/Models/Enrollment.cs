using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThucHanh_4_5_6_CF.Models
{
    public class Enrollment
    {
        public int EnrollmentID {get; set;}
        public int CourseID {get; set;}
        public int LearnerID {get; set;}
        public decimal Grade {get; set;}
        public virtual Course Course {get; set;}
        public virtual Learner Learner {get; set;}
    }
}