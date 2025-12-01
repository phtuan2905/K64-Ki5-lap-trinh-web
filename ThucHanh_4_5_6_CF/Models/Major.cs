using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThucHanh_4_5_6_CF.Models
{
    public class Major
    {
        public int MajorID {get; set;}
        public string MajorName {get; set;}
        public ICollection<Learner> Learners {get; set;}
    }
}