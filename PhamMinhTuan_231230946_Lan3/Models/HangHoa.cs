using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhamMinhTuan_231230946_Lan3.Models;

public partial class HangHoa
{
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    public string TenHang { get; set; } = null!;

    [Range(minimum: 100, maximum: 5000)]
    public decimal? Gia { get; set; }

    public string? Anh { get; set; }

    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
