using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhamMinhTuan_231230946.Models;

namespace PhamMinhTuan_231230946.ViewComponents
{
    public class TuyenDropDownViewComponent : ViewComponent
    {   
        private VanTai2512V1Context db;
        private List<Tuyen> tuyens = new List<Tuyen>();

        public TuyenDropDownViewComponent(VanTai2512V1Context context)
        {
            db = context;
            tuyens = db.Tuyens.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Tuyens = new SelectList(tuyens, "MaTuyen", "TenTuyen");
            return View("Index");
        }
    }
}