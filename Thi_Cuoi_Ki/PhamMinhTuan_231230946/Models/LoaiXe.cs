using System;
using System.Collections.Generic;

namespace PhamMinhTuan_231230946.Models;

public partial class LoaiXe
{
    public int MaLoaiXe { get; set; }

    public string? TenLoaiXe { get; set; }

    public virtual ICollection<Xe> Xes { get; set; } = new List<Xe>();
}
