using EduHome.Models;
using EduHome.Models.DbTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CourseController : Controller
    {
        private readonly MyContext db;

        public CourseController(MyContext context)
        {
            db = context;
        }


        public async Task<IActionResult>  Courses()
        {
           List<Models.DbTables.Course> crs = await db.Courses.ToListAsync();
            return View(crs);
        }

        public async Task<IActionResult> CourseDetails(int? id)
        {
            if (id == null) id = db.Courses.First().id;
            Models.DbTables.Course course = await db.Courses.Include(x=>x.Category).Include(x=>x.CourseFeatures).Include(x=>x.Compaigns).FirstOrDefaultAsync(x => x.id == id);

            return View(course);
        }
    }
}
