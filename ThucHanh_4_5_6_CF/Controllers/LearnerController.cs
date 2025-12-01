using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ThucHanh_4_5_6_CF.Data;
using ThucHanh_4_5_6_CF.Models;

namespace ThucHanh_4_5_6_CF.Controllers
{
    [Route("[controller]")]
    public class LearnerController : Controller
    {
        private TH456CFContext db;
        private int pageSize = 2;
        public LearnerController(TH456CFContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var learners = db.Learner.Take(pageSize).Include(l => l.Major).ToList();
            ViewBag.TotalPage = (int)Math.Ceiling(db.Learner.Count() / (float)pageSize);
            return View("Index", learners);
        }

        [HttpGet("Filter")]
        public IActionResult Filter(int mid = -1, int pageNumber = 1)
        {
            
            if (mid != -1)
            {
                var learners = db.Learner.Where(l => l.MajorID == mid).Skip(pageSize * (pageNumber - 1)).Take(pageSize).Include(l => l.Major).ToList();
                ViewBag.Filter = mid;
                ViewBag.TotalPage = (int)Math.Ceiling(db.Learner.Where(l => l.MajorID == mid).Count() / (float)pageSize);
                return PartialView("FilterTable", learners);
            }
            else
            {
                var learners = db.Learner.Skip(pageSize * (pageNumber - 1)).Take(pageSize).Include(l => l.Major).ToList();
                ViewBag.Filter = -1;
                ViewBag.TotalPage = (int)Math.Ceiling(db.Learner.Count() / (float)pageSize);
                return PartialView("FilterTable", learners);
            }
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewBag.Majors = new SelectList(db.Major.ToList(), "MajorID", "MajorName");
            return View("Create");
        }

        [HttpPost("Create")]
        public IActionResult Create(Learner learner)
        {
            db.Learner.Add(learner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("Update/{id}")]
        public IActionResult Update(int id)
        {
            var learner = db.Learner.Find(id);
            if (learner == null) return RedirectToAction("Index");
            ViewBag.Majors = new SelectList(db.Major.ToList(), "MajorID", "MajorName");
            ViewBag.EnrollmentDate = learner.EnrollmentDate.ToString("yyyy-MM-dd");
            return View("Update", learner);
        }

        [HttpPost("Update/{id}")]
        public IActionResult Update(int id, Learner learner)
        {
            db.Update(learner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("Detele/{id}")]
        public IActionResult Delete(int id)
        {
            var learner = db.Learner.Find(id);
            return View("Delete", learner);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult DeleteLearner(int id)
        {
            var learner = db.Learner.Find(id);
            db.Learner.Remove(learner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}