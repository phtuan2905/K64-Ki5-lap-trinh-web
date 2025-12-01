using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PhamMinhTuan_231230946_Lan4.Models;

namespace PhamMinhTuan_231230946_Lan4.Controllers
{
    [Route("[controller]")]
    public class SachController : Controller
    {
        private QlsachContext db;

        public SachController(QlsachContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var sachs = db.Saches.Where(s => s.DonGia >= 100).ToList();
            return View("Index", sachs);
        }

        [HttpGet("Filter")]
        public IActionResult Filter(int mlh)
        {
            var sachs = db.Saches.Where(s => s.DonGia >= 100 && s.LoaiHangId == mlh).ToList();
            return PartialView("FilterTable", sachs);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewBag.LoaiHangs = new SelectList(db.LoaiHangs.ToList(), "LoaiHangId", "TenLoai");
            return View("Create");
        }

        [HttpPost("Create")]
        public IActionResult Create(Sach sach)
        {
            db.Saches.Add(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}