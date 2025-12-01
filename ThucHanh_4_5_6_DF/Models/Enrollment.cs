using System;
using System.Collections.Generic;

namespace ThucHanh_4_5_6_DF.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int CourseId { get; set; }

    public int LearnerId { get; set; }

    public decimal Grade { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
