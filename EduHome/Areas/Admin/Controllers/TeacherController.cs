using EduHome.Extensions;
using EduHome.Models;
using EduHome.Models.DbTables;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin/[controller]/[action]")]
    public class TeacherController : Controller
    {
        private readonly MyContext context;
        private readonly IWebHostEnvironment webHost;

        public TeacherController(MyContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }

        public IActionResult Index(int page = 1)
        {
            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = Math.Ceiling((decimal)context.Teachers.Count() / 3);
            List<Teacher> teachers = context.Teachers.Skip((page - 1) * 3).Take(3).ToList();
            return View(teachers);
        }

        #region Teacher Table CRUD
        public IActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(Teacher teacher)
        {
            if (!ModelState.IsValid) return View();

            if (!teacher.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "image type is not Correct");
                return View();
            }

            string folder = @"img\teacher\";
            teacher.Image = teacher.Photo.SavaAsync(webHost.WebRootPath, folder).Result;
            context.Teachers.Add(teacher);
            await context.SaveChangesAsync();


            return LocalRedirect("/admin/Teacher/index");
        }

        public IActionResult UpdateTeacher(int id)
        {
            Teacher teacher = context.Teachers.FirstOrDefault(x => x.id == id);
            if (teacher == null) return NotFound();

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTeacher(Teacher teacher)
        {
            if (!ModelState.IsValid) return View(teacher);
            Teacher existTeacher = context.Teachers.FirstOrDefault(x => x.id == teacher.id);
            if (existTeacher == null) return NotFound();

            if (teacher.Photo != null)
            {
                try
                {
                    string folder = @"img\teacher\";
                    string newImg = await teacher.Photo.SavaAsync(webHost.WebRootPath, folder);
                    FileExtension.Delete(webHost.WebRootPath, folder, existTeacher.Image);
                    existTeacher.Image = newImg;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "unexpected error for Update");
                    return View();
                }

            }
            existTeacher.Name = teacher.Name;
            existTeacher.Surname = teacher.Surname;
            existTeacher.Job = teacher.Job;
            existTeacher.About = teacher.About;
            existTeacher.Degree = teacher.Degree;
            existTeacher.Experience = teacher.Experience;

            context.SaveChanges();
            return LocalRedirect("/admin/Teacher/index");
        }

        public IActionResult DeleteTeacher(int id)
        {
            Teacher existTeacher = context.Teachers.FirstOrDefault(x => x.id == id);
            if (existTeacher == null) return NotFound();
            Skill skill = context.Skills.FirstOrDefault(x => x.TeacherId == id);
            if (skill != null) context.Skills.Remove(skill);
            List<TeacherHobby> teacherHobbies = context.TeacherHobbies.Where(x => x.TeacherId == id).ToList();
            if (teacherHobbies != null) context.TeacherHobbies.RemoveRange(teacherHobbies);
            List<TeacherFaculty> teacherFaculties = context.TeacherFaculties.Where(x => x.TeacherId == id).ToList();
            if (teacherHobbies != null) context.TeacherFaculties.RemoveRange(teacherFaculties);


            string folder = @"img\teacher\";
            FileExtension.Delete(webHost.WebRootPath, folder, existTeacher.Image);
            context.Teachers.Remove(existTeacher);
            context.SaveChanges();
            return LocalRedirect("/admin/Teacher/index");
        }

        #endregion


        #region Contact Info CRUD

        public IActionResult AddSkill(int id)
        {
            Skill existskill = context.Skills.FirstOrDefault(x => x.TeacherId == id);
            if (existskill == null) return NotFound();
            ViewBag.Teachers = context.Teachers.ToList();

            Skill skill = new Skill()
            {
                TeacherId = id
            };

            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSkill(Skill skill)
        {
            if (!ModelState.IsValid) return View(skill);
            context.Skills.Add(skill);
            await context.SaveChangesAsync();

            return View();
        }

        public IActionResult UpdateSkill(int id)
        {
            Skill skill = context.Skills.FirstOrDefault(x => x.TeacherId == id);
            if (skill == null) return NotFound();


            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSkill(Skill skill)
        {
            if (!ModelState.IsValid) return View(skill);
            Skill existSkill = context.Skills.FirstOrDefault(x => x.TeacherId == skill.id);
            if (existSkill == null) return NotFound();
            existSkill.Language = skill.Language;
            existSkill.Leader = skill.Leader;
            existSkill.Development = skill.Development;
            existSkill.Design = skill.Design;
            existSkill.Innovation = skill.Innovation;
            existSkill.Communication = skill.Communication;
            await context.SaveChangesAsync();

            return View();
        }

        #endregion

        #region Faculty and Hobby
        public IActionResult AddFacultyHobby()
        {
            ViewBag.Teachers = context.Teachers.ToList();
            ViewBag.Faculties = context.Faculties.ToList();
            ViewBag.Hobbies = context.Hobbies.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFacultyHobby(FacultyHobbyVM facultyHobby)
        {
            if (!ModelState.IsValid) return View(facultyHobby);
            
            ViewBag.Teachers = context.Teachers.ToList();
            ViewBag.Faculties = context.Faculties.ToList();
            ViewBag.Hobbies = context.Hobbies.ToList();
            List<TeacherFaculty> teacherFaculties = new List<TeacherFaculty>();

            foreach (var item in facultyHobby.FacultyIds)
            {
                TeacherFaculty teacherFaculty = new TeacherFaculty()
                {
                    TeacherId = facultyHobby.TeacherId,
                    FacultyId = item
                };

                context.TeacherFaculties.Add(teacherFaculty);
            }

            List<TeacherHobby> teacherHobbies = new List<TeacherHobby>();

            foreach (var item in facultyHobby.HobbyIds)
            {
                TeacherHobby teacherHobby = new TeacherHobby()
                {
                    TeacherId = facultyHobby.TeacherId,
                    HobbyId = item
                };

                context.TeacherHobbies.Add(teacherHobby);
            }

            await context.SaveChangesAsync();


            return View();
        }


        #endregion

    }
}
