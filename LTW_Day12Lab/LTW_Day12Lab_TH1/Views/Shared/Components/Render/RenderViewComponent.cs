using LTW_Day12Lab_TH1_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LTW_Day12Lab_TH1_2.Views.Shared.Components.Render
{
    [ViewComponent]
    public class RenderViewComponent
    {
        private List<MenuItem> MenuItems = new List<MenuItem>();

        public RenderViewComponent()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Branches", Link = "Branches/List" },
                new MenuItem() { Id = 2, Name = "Students", Link = "Students/List" },
                new MenuItem() { Id = 3, Name = "Subjects", Link = "Subjects/List" },
                new MenuItem() { Id = 4, Name = "Courses", Link = "Courses/List" }
            };
        }
    }
}
