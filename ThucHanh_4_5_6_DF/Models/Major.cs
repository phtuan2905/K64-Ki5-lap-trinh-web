using System;
using System.Collections.Generic;

namespace ThucHanh_4_5_6_DF.Models;

public partial class Major
{
    public int MajorId { get; set; }

    public string MajorName { get; set; } = null!;

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
