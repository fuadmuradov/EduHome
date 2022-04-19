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

        #region Course CRUD

        public IActionResult CoursePage(int page = 1)
        {
            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = Math.Ceiling((decimal)context.Courses.Count() / 3);
            List<Course> courses = context.Courses.Skip((page - 1) * 3).Take(3).ToList();
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

            TempData["CourseId"] = course.id;

            return LocalRedirect("/admin/Course/CreateFeature");
        }


        public IActionResult UpdateCourse(int id)
        {
            ViewBag.Categories = context.Categories.ToList();
            Course course = context.Courses.FirstOrDefault(x => x.id == id);
            if (course == null) return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCourse(Course course)
        {
            ViewBag.Categories = context.Categories.ToList();
            if (!ModelState.IsValid) return View(course);
            Course existCourse = context.Courses.FirstOrDefault(x=>x.id==course.id);
            if (existCourse == null) return NotFound();

            if (course.Photo != null)
            {
                try
                {
                    string folder = @"img\course\";
                    string newImg = await course.Photo.SavaAsync(webHost.WebRootPath, folder);
                    FileExtension.Delete(webHost.WebRootPath, folder, existCourse.Image);
                    existCourse.Image = newImg;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "unexpected error for Update");
                    return View();
                }

            }
            existCourse.Name = course.Name;
            existCourse.Description = course.Description;
            existCourse.About = course.About;
            existCourse.Apply = course.Apply;
            existCourse.Certification = course.Certification;
            existCourse.CategoryId = course.CategoryId;
            context.SaveChanges();
            return LocalRedirect("/admin/Course/CoursePage");
        }


        public IActionResult DeleteCourse(int Id)
        {
            Course course = context.Courses.FirstOrDefault(x => x.id == Id);
            if (course == null) return NotFound();
            CourseFeature courseFeature = context.CourseFeatures.FirstOrDefault(x => x.CourseId == course.id);
            Compaign compaign = context.Compaigns.FirstOrDefault(x => x.CourseId == course.id);

            if (courseFeature != null)
                context.CourseFeatures.Remove(courseFeature);
            if (compaign != null)
                context.Compaigns.Remove(compaign);
            context.Courses.Remove(course);

            string folder = @"img\course\";
            FileExtension.Delete(webHost.WebRootPath, folder, course.Image);
            context.Courses.Remove(course);
            context.SaveChanges();

            return LocalRedirect("/Admin/Course/CoursePage");

        }

        #endregion

        #region CourseFeature
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFeature(CourseFeature courseFeature)
        {
            if (!ModelState.IsValid) return View();
            int courseId = 0;
            courseId = Convert.ToInt32(TempData["CourseId"]);
            courseFeature.CourseId = courseId;
            context.CourseFeatures.Add(courseFeature);
            await context.SaveChangesAsync();
            return LocalRedirect("/Admin/Course/CoursePage");
        }

        public IActionResult UpdateFeature(int id)
        {
            CourseFeature course = context.CourseFeatures.FirstOrDefault(x => x.CourseId == id);
            if (course == null) return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFeature(CourseFeature courseFeature)
        {
            if (!ModelState.IsValid) return View();
            CourseFeature existCourseFeature = context.CourseFeatures.FirstOrDefault(x => x.CourseId == courseFeature.CourseId);
            if (existCourseFeature == null) return NotFound();
            existCourseFeature.StartDate = courseFeature.StartDate;
            existCourseFeature.Duration = courseFeature.Duration;
            existCourseFeature.ClassDuration = courseFeature.ClassDuration;
            existCourseFeature.SkilLevel = courseFeature.SkilLevel;
            existCourseFeature.Language = courseFeature.Language;
            existCourseFeature.StudentCount = courseFeature.StudentCount;
            existCourseFeature.Assesment = courseFeature.Assesment;
            existCourseFeature.Price = courseFeature.Price;

            await context.SaveChangesAsync();
            return LocalRedirect("/Admin/Course/CoursePage");
        }



        #endregion
    }
}
