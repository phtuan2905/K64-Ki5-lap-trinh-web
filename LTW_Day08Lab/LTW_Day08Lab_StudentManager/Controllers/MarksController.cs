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
    public class MarksController : Controller
    {
        private readonly AppDbContext _context;

        public MarksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Marks.Include(m => m.Students).Include(m => m.Subjects);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks
                .Include(m => m.Students)
                .Include(m => m.Subjects)
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "StudentAddress");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName");
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,StudentId,Score")] Marks marks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "StudentAddress", marks.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", marks.SubjectId);
            return View(marks);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks.FindAsync(id);
            if (marks == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "StudentAddress", marks.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", marks.SubjectId);
            return View(marks);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,StudentId,Score")] Marks marks)
        {
            if (id != marks.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarksExists(marks.SubjectId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "StudentAddress", marks.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", marks.SubjectId);
            return View(marks);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks
                .Include(m => m.Students)
                .Include(m => m.Subjects)
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marks = await _context.Marks.FindAsync(id);
            if (marks != null)
            {
                _context.Marks.Remove(marks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarksExists(int id)
        {
            return _context.Marks.Any(e => e.SubjectId == id);
        }
    }
}
