using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhamMinhTuan_231230946.Models;

namespace PhamMinhTuan_231230946.Controllers;

[Route("{controller}")]
public class HomeController : Controller
{
    private VanTai2512V1Context db;
    public HomeController(VanTai2512V1Context context)
    {
        db = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var chuyens = db.Chuyens.Include(c => c.MaLaiXeNavigation).Include(c => c.MaTuyenNavigation).Include(c => c.SoXeNavigation).Take(6).OrderByDescending(c => c.SoXe).ToList();
        return View("Index", chuyens);
    }

    [HttpGet("Filter")]
    public IActionResult Filter(string tid)
    {
        var chuyens = db.Chuyens.Include(c => c.MaLaiXeNavigation).Include(c => c.MaTuyenNavigation).Include(c => c.SoXeNavigation).Where(c => c.MaTuyen == tid).OrderByDescending(c => c.SoXe).ToList();
        return PartialView("Filter", chuyens);
    }

    [HttpGet("Edit")]
    public IActionResult Edit(int cid)
    {
        var chuyen = db.Chuyens.Find(cid);
        return View("Edit", chuyen);
    }

    [HttpPost("Edit")]
    public IActionResult Edit(int cid, Chuyen c)
    {
        db.Update(c);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
