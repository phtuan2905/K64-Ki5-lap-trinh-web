using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LTW_Day09Lab_CodeFirst.Models;

namespace LTW_Day09Lab_CodeFirst.Controllers
{
    public class TvcSanPhamsController : Controller
    {
        private readonly TvcDay09LabCFContext _context;

        public TvcSanPhamsController(TvcDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: TvcSanPhams
        public async Task<IActionResult> Index()
        {
            var tvcDay09LabCFContext = _context.tvcSanPhams.Include(t => t.TvcLoaiSanPham);
            return View(await tvcDay09LabCFContext.ToListAsync());
        }

        // GET: TvcSanPhams/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcSanPham = await _context.tvcSanPhams
                .Include(t => t.TvcLoaiSanPham)
                .FirstOrDefaultAsync(m => m.tvcID == id);
            if (tvcSanPham == null)
            {
                return NotFound();
            }

            return View(tvcSanPham);
        }

        // GET: TvcSanPhams/Create
        public IActionResult Create()
        {
            ViewData["tvcLoaiSanPhamID"] = new SelectList(_context.tvcLoaiSanPhams, "tvcId", "tvcId");
            return View();
        }

        // POST: TvcSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tvcID,tvcMaSanPham,tvcTenSanPham,tvcHinhAnh,tvcSoLuong,tvcDonGia,tvcLoaiSanPhamID")] TvcSanPham tvcSanPham)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(tvcSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tvcLoaiSanPhamID"] = new SelectList(_context.tvcLoaiSanPhams, "tvcId", "tvcId", tvcSanPham.tvcLoaiSanPhamID);
            return View(tvcSanPham);
        }

        // GET: TvcSanPhams/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcSanPham = await _context.tvcSanPhams.FindAsync(id);
            if (tvcSanPham == null)
            {
                return NotFound();
            }
            ViewData["tvcLoaiSanPhamID"] = new SelectList(_context.tvcLoaiSanPhams, "tvcId", "tvcId", tvcSanPham.tvcLoaiSanPhamID);
            return View(tvcSanPham);
        }

        // POST: TvcSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("tvcID,tvcMaSanPham,tvcTenSanPham,tvcHinhAnh,tvcSoLuong,tvcDonGia,tvcLoaiSanPhamID")] TvcSanPham tvcSanPham)
        {
            if (id != tvcSanPham.tvcID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvcSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvcSanPhamExists(tvcSanPham.tvcID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["tvcLoaiSanPhamID"] = new SelectList(_context.tvcLoaiSanPhams, "tvcId", "tvcId", tvcSanPham.tvcLoaiSanPhamID);
            return View(tvcSanPham);
        }

        // GET: TvcSanPhams/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcSanPham = await _context.tvcSanPhams
                .Include(t => t.TvcLoaiSanPham)
                .FirstOrDefaultAsync(m => m.tvcID == id);
            if (tvcSanPham == null)
            {
                return NotFound();
            }

            return View(tvcSanPham);
        }

        // POST: TvcSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tvcSanPham = await _context.tvcSanPhams.FindAsync(id);
            if (tvcSanPham != null)
            {
                _context.tvcSanPhams.Remove(tvcSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvcSanPhamExists(long id)
        {
            return _context.tvcSanPhams.Any(e => e.tvcID == id);
        }
    }
}
