using EduHome.Extensions;
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


        public IActionResult CoursePage(int page=1)
        {
            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = Math.Ceiling((decimal)context.Courses.Count() / 3);
            List<Course> courses = context.Courses.Skip((page-1)*3).Take(3).ToList();
            return View(courses);
        }

        public IActionResult CreateCourse()
        {
            ViewBag.Categories = context.Categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCourse(Course course)
        {
            ViewBag.Categories = context.Categories.ToList();

            if (!ModelState.IsValid) return View();

            if (!course.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "image type is not Correct");
                return View();
            }

            string folder = @"img\course\";
            course.Image = course.Photo.SavaAsync(webHost.WebRootPath, folder).Result;
            context.Courses.Add(course);
            await context.SaveChangesAsync();


           
            return LocalRedirect("/admin/Course/Coursepage");
        }


        public IActionResult DeleteCourse(int Id)
        {
            Course course = context.Courses.FirstOrDefault(x => x.id == Id);
            if (course == null) return NotFound();
            CourseFeature courseFeature = context.CourseFeatures.FirstOrDefault(x => x.CourseId == course.id);
            Compaign compaign = context.Compaigns.FirstOrDefault(x => x.CourseId == course.id);
            context.CourseFeatures.Remove(courseFeature);
            context.Compaigns.Remove(compaign);
            context.SaveChanges();



            string folder = @"img\course\";
            FileExtension.Delete(webHost.WebRootPath, folder, course.Image);
            context.Courses.Remove(course);
            context.SaveChanges();

            return LocalRedirect("/Admin/Course/CoursePage");

        }


    }
}
