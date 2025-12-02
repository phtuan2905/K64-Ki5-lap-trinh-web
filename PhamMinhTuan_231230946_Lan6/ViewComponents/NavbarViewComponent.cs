using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhamMinhTuan_231230946_Lan6.Models;

namespace PhamMinhTuan_231230946_Lan6.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private PmtBookStoreDbContext db;
        private List<Category> categories = new List<Category>();

        public NavbarViewComponent(PmtBookStoreDbContext context)
        {
            db = context;
            categories = db.Categories.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index", categories);
        } 
    }
}