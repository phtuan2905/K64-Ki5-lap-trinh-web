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
        private int pageSize = 5;

        public SachController(QlsachContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var totalSachs = db.Saches.Where(s => s.DonGia >= 100).ToList();
            var sachs = totalSachs.Take(pageSize).ToList();
            ViewBag.TotalPage = (int)Math.Ceiling(totalSachs.Count / (float)pageSize);
            return View("Index", sachs);
        }

        [HttpGet("Filter")]
        public IActionResult Filter(int mlh = -1, string keyword = "", int pageNumber = 1)
        {
            if (mlh == -1)
            {
                var totalSachs = db.Saches.Where(s => s.DonGia >= 100 && s.TenSach.ToLower().Contains(keyword.ToLower())).ToList();
                var sachs = totalSachs.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
                ViewBag.TotalPage = (int)Math.Ceiling(totalSachs.Count / (float)pageSize);
                ViewBag.Filter = mlh;
                ViewBag.Keyword = keyword;
                return PartialView("FilterTable", sachs);
            }
            else
            {
                var totalSachs = db.Saches.Where(s => s.DonGia >= 100 && s.LoaiHangId == mlh && s.TenSach.ToLower().Contains(keyword.ToLower())).ToList();
                var sachs = totalSachs.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
                ViewBag.TotalPage = (int)Math.Ceiling(totalSachs.Count / (float)pageSize);
                ViewBag.Filter = mlh;
                ViewBag.Keyword = keyword;
                return PartialView("FilterTable", sachs);
                }
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