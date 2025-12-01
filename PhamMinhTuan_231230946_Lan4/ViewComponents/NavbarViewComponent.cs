using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhamMinhTuan_231230946_Lan4.Models;

namespace PhamMinhTuan_231230946_Lan4.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private QlsachContext db;
        private List<LoaiHang> loaiHangs = new List<LoaiHang>();

        public NavbarViewComponent(QlsachContext context)
        {
            db = context;
            loaiHangs = db.LoaiHangs.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index", loaiHangs);
        }
    }
}