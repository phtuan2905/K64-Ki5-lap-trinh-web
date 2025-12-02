using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PhamMinhTuan_231230946_Lan1.Models;

namespace PhamMinhTuan_231230946_Lan1.Controllers
{
    [Route("[controller]")]
    public class HangHoaController : Controller
    {
        private QlhangHoaContext db;
        private readonly ILogger<HangHoaController> _logger;
        private int pageSize = 5;

        public HangHoaController(ILogger<HangHoaController> logger, QlhangHoaContext _context)
        {
            _logger = logger;
            db = _context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var totalHangHoas = db.HangHoas.Where(h => h.Gia >= 100).ToList();
            ViewBag.TotalPage = (int)Math.Ceiling(totalHangHoas.Count / (float)pageSize);
            var hangHoas = db.HangHoas.Take(pageSize).Where(h => h.Gia >= 100).ToList();
            return View("Index", hangHoas);
        }

        [HttpGet("Filter")]
        public IActionResult HangHoaTable(int mlh = -1, string keyword = "", int pageNumber = 1)
        {
            if (mlh == -1)
            {
                var totalHangHoas = db.HangHoas.Where(h => h.Gia >= 100 && h.TenHang.ToLower().Contains(keyword)).ToList();
                var hangHoas = db.HangHoas.Where(h => h.Gia >= 100 && h.TenHang.ToLower().Contains(keyword)).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
                ViewBag.TotalPage = (int)Math.Ceiling(totalHangHoas.Count / (float)pageSize);
                ViewBag.Filter = mlh;
                ViewBag.keyword = keyword;
                return PartialView("HangHoaTable", hangHoas);
            }
            else
            {
                var totalHangHoas = db.HangHoas.Where(h => h.Gia >= 100 && h.MaLoai == mlh && h.MaLoai == mlh).ToList();
                var hangHoas = db.HangHoas.Where(h => h.Gia >= 100 && h.MaLoai == mlh && h.TenHang.ToLower().Contains(keyword)).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
                ViewBag.TotalPage = (int)Math.Ceiling(totalHangHoas.Count / (float)pageSize);
                ViewBag.Filter = mlh;
                ViewBag.keyword = keyword;
                return PartialView("HangHoaTable", hangHoas);
            }
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewBag.loaihangs = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
            return View("Create");
        }
        
        [HttpPost("Create")]
        public IActionResult Create(HangHoa hangHoa)
        {
            db.HangHoas.Add(hangHoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}