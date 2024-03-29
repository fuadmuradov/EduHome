﻿using EduHome.Models;
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
                Slider = await db.Sliders.Include(Image => Image.SliderImages).FirstAsync(),
                Notices = await db.Notices.ToListAsync(),
                NoticeSeconds = await db.NoticeSeconds.ToListAsync(),
                Events = await db.Events.ToListAsync(),
                Blogs = await db.Blogs.OrderByDescending(d => d.Date).ToListAsync(),
                Courses = await db.Courses.OrderByDescending(d=>d.id).ToListAsync()
            };

            return View(homeVM);
        }


        public async Task<IActionResult> About()
        {
            AboutVM about = new AboutVM
            {
                About = await db.Abouts.FirstAsync(),
                Teachers = await db.Teachers.Include(c=>c.Contacts).ToListAsync(),
                Testimional = await db.Testimionals.FirstAsync(),
                Notices = await db.Notices.ToListAsync()
            };


            return View(about);
        }














        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
