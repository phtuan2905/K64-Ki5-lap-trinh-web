using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThucHanh_4_5_6_CF.Data;
using ThucHanh_4_5_6_CF.Models;

namespace ThucHanh_4_5_6_CF.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public TH456CFContext db;
        public List<Major> majors = new List<Major>();

        public NavbarViewComponent(TH456CFContext context)
        {
            db = context;
            majors = db.Major.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index", majors);
        }
    }
}