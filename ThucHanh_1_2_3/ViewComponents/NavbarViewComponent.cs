using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThucHanh_1_2_3.Models;

namespace ThucHanh_1_2_3.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private List<MenuItem> menuItems = new List<MenuItem>()
        {
            new MenuItem()
            {
                Controller = "Student",
                Action = "Index",
                Name = "Student List"
            },
            new MenuItem()
            {
                Controller = "Student",
                Action = "Create",
                Name = "Create Student"
            }
        };

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Navbar", menuItems);
        }
    }
}