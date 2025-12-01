using System;
using System.Collections.Generic;

namespace PhamMinhTuan_231230946_Lan4.Models;

public partial class LoaiHang
{
    public int LoaiHangId { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
