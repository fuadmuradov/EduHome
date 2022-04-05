using EduHome.Models;
using EduHome.Models.DbTables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CourseController : Controller
    {
        private readonly MyContext context;
        private readonly IWebHostEnvironment webHost;

        public CourseController(MyContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }

        public IActionResult Category()
        {
            List<Category> categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Category(string Name)
        {
            Category category = new Category();
            category.Name = Name;
            context.Categories.Add(category);
             context.SaveChanges();

            return View(context.Categories.ToList());
        }

        public async Task<IActionResult> DeleteCategory(int Id)
        {
            Category existcategory = await context.Categories.FirstOrDefaultAsync(x => x.id == Id);
            if (existcategory == null) return NotFound();
            context.Categories.Remove(existcategory);
            await context.SaveChangesAsync();

            return LocalRedirect("/Admin/Course/Category");
        }


        public IActionResult CoursePage()
        {
            return View();
        }
    }
}
