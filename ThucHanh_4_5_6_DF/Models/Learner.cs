using System;
using System.Collections.Generic;

namespace ThucHanh_4_5_6_DF.Models;

public partial class Learner
{
    public int LearnerId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public DateOnly EnrollmentDate { get; set; }

    public int MajorId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Major Major { get; set; } = null!;
}
