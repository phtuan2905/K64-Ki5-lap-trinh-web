using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhamMinhTuan_231230946_Lan2.Models;

namespace PhamMinhTuan_231230946_Lan2.Controllers
{
    [Route("[controller]")]
    public class HangHoaController : Controller
    {
        private QlhangHoaContext db;
        private readonly ILogger<HangHoaController> _logger;

        public HangHoaController(ILogger<HangHoaController> logger, QlhangHoaContext context)
        {
            _logger = logger;
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var hangHoas = db.HangHoas.Where(h => h.Gia >= 100).ToList();
            return View("Index", hangHoas);
        }

        [HttpGet("Filter")] 
        public IActionResult Filter(int mlh)
        {
            var hangHoas = db.HangHoas.Where(h => h.Gia >= 100 && h.MaLoai == mlh).ToList();
            return PartialView("HangHoaTable", hangHoas);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewBag.LoaiHangs = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
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