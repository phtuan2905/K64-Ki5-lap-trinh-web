using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LTW_Day08Lab_StudentManager.Entities;
using LTW_Day08Lab_StudentManager.Models;

namespace LTW_Day08Lab_StudentManager.Controllers
{
    public class StdClassesController : Controller
    {
        private readonly AppDbContext _context;

        public StdClassesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StdClassses
        public async Task<IActionResult> Index()
        {
            return View(await _context.StdClasses.ToListAsync());
        }

        // GET: StdClassses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdClasss = await _context.StdClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stdClasss == null)
            {
                return NotFound();
            }

            return View(stdClasss);
        }

        // GET: StdClassses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StdClassses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StdClass stdClasss)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stdClasss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stdClasss);
        }

        // GET: StdClassses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdClasss = await _context.StdClasses.FindAsync(id);
            if (stdClasss == null)
            {
                return NotFound();
            }
            return View(stdClasss);
        }

        // POST: StdClassses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] StdClass stdClasss)
        {
            if (id != stdClasss.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stdClasss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StdClasssExists(stdClasss.Id))
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
            return View(stdClasss);
        }

        // GET: StdClassses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdClasss = await _context.StdClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stdClasss == null)
            {
                return NotFound();
            }

            return View(stdClasss);
        }

        // POST: StdClassses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stdClasss = await _context.StdClasses.FindAsync(id);
            if (stdClasss != null)
            {
                _context.StdClasses.Remove(stdClasss);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StdClasssExists(int id)
        {
            return _context.StdClasses.Any(e => e.Id == id);
        }
    }
}
