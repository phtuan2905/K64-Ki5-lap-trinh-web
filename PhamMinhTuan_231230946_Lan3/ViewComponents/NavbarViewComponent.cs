using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhamMinhTuan_231230946_Lan3.Models;

namespace PhamMinhTuan_231230946_Lan3.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public QlhangHoaContext db;
        public List<LoaiHang> loaiHangs;

        public NavbarViewComponent(QlhangHoaContext context)
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