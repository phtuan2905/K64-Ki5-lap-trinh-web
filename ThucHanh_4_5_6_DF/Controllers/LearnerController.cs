using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ThucHanh_4_5_6_DF.Models;

namespace ThucHanh_4_5_6_CF.Controllers
{
    [Route("[controller]")]
    public class LearnerController : Controller
    {
        private Th456CfContext db;
        public LearnerController(Th456CfContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var learners = db.Learners.ToList();
            return View("Index", learners);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewBag.Majors = new SelectList(db.Majors.ToList(), "MajorId", "MajorName");
            return View("Create");
        }

        [HttpPost("Create")]
        public IActionResult Create(Learner learner)
        {
            db.Learners.Add(learner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("Update/{id}")]
        public IActionResult Update(int id)
        {
            var learner = db.Learners.Find(id);
            if (learner == null) return RedirectToAction("Index");
            ViewBag.Majors = new SelectList(db.Majors.ToList(), "MajorId", "MajorName");
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
            var learner = db.Learners.Find(id);
            return View("Delete", learner);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult DeleteLearner(int id)
        {
            var learner = db.Learners.Find(id);
            db.Learners.Remove(learner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}