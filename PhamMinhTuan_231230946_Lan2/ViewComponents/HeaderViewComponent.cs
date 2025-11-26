using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhamMinhTuan_231230946_Lan2.Models;

namespace PhamMinhTuan_231230946_Lan2.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private QlhangHoaContext db;
        private List<LoaiHang> loaiHangs;

        public HeaderViewComponent(QlhangHoaContext _context)
        {
            db = _context;
            loaiHangs = db.LoaiHangs.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index", loaiHangs);
        }
    }
}