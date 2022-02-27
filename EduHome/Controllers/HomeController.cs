using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {

        private readonly MyContext db;

        public HomeController(MyContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Slider = db.Sliders.Include(Image=>Image.SliderImages).First(),
                Notices = db.Notices.ToList(),
                NoticeSeconds = db.NoticeSeconds.ToList()
            };

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
