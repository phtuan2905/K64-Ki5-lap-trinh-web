using System;
using System.Collections.Generic;

namespace PhamMinhTuan_231230946_Lan4.Models;

public partial class Sach
{
    public int SachId { get; set; }

    public string TenSach { get; set; } = null!;

    public decimal DonGia { get; set; }

    public int NamXuatBan { get; set; }

    public int LoaiHangId { get; set; }

    public virtual LoaiHang LoaiHang { get; set; } = null!;
}
