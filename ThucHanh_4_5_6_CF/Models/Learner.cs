using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThucHanh_4_5_6_CF.Models
{
    public class Learner
    {
        public int LearnerID {get; set;}
        public string LastName {get; set;}
        public string FirstName {get; set;}
        public DateOnly EnrollmentDate {get; set;}
        public int MajorID {get; set;}
        public virtual Major Major {get; set;}
        public virtual ICollection<Enrollment> Enrollments {get; set;}
    }
}