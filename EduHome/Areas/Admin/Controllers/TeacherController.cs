using EduHome.Extensions;
using EduHome.Models;
using EduHome.Models.DbTables;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
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
        [ValidateAntiForgeryToken]
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
            TempData["teacherId"] = teacher.id.ToString();

            return LocalRedirect("/admin/Teacher/AddContact");
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
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);
            contact.TeacherId = Convert.ToInt32(TempData["teacherId"]);
            await context.Contact.AddAsync(contact);
            await context.SaveChangesAsync();

            return LocalRedirect("/admin/Teacher/AddSkill?Tid=" + TempData["teacherId"].ToString());
        }

        public IActionResult UpdateContact(int Tid)
        {
            Contact existcontact = context.Contact.FirstOrDefault(x => x.TeacherId == Tid);
            if (existcontact == null) return NotFound();
            return View(existcontact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateContact(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);
            Contact existcontact2 = context.Contact.FirstOrDefault(x => x.TeacherId == contact.TeacherId);
            if (existcontact2 == null) return NotFound();
            existcontact2.Mail = contact.Mail;
            existcontact2.Phone = contact.Phone;
            existcontact2.SkypeName = contact.SkypeName;
            existcontact2.SkypeUrl = contact.SkypeUrl;
            existcontact2.FacebookUrl = contact.FacebookUrl;
            existcontact2.PinterestUrl = contact.PinterestUrl;
            existcontact2.TwitterUrl = contact.TwitterUrl;

            await context.SaveChangesAsync();

            return View();
        }


        #endregion

        #region SKILL crud

        public IActionResult AddSkill(int Tid)
        {
            Skill existskill = context.Skills.FirstOrDefault(x => x.TeacherId == Tid);
            if (existskill != null) return BadRequest();
            ViewBag.Teachers = context.Teachers.ToList();
            Skill skilll = new Skill()
            {
                TeacherId = Tid
            };
            return View(skilll);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSkill(Skill skill)
        {
            if (!ModelState.IsValid) return View(skill);
            context.Skills.Add(skill);
            context.SaveChanges();

            return LocalRedirect("/admin/Teacher/AddFacultyHobby?Tid="+skill.TeacherId.ToString());
        }

        public IActionResult UpdateSkill(int Tid)
        {
            Skill skill = context.Skills.FirstOrDefault(x => x.TeacherId == Tid);
            if (skill == null) return NotFound();


            return View(skill);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSkill(Skill skill)
        {
            if (!ModelState.IsValid) return View(skill);
            Skill existSkill = context.Skills.FirstOrDefault(x => x.TeacherId == skill.TeacherId);
            if (existSkill == null) return NotFound();
            existSkill.Language = skill.Language;
            existSkill.Leader = skill.Leader;
            existSkill.Development = skill.Development;
            existSkill.Design = skill.Design;
            existSkill.Innovation = skill.Innovation;
            existSkill.Communication = skill.Communication;
            await context.SaveChangesAsync();

            return LocalRedirect("/admin/teacher/index");
        }

        #endregion

        #region Faculty and Hobby
        public IActionResult AddFacultyHobby(int Tid)
        {
            FacultyHobbyVM facultyHobbyVM = new FacultyHobbyVM()
            {
                TeacherId = Tid
            };
            ViewBag.Teachers = context.Teachers.ToList();
            ViewBag.Faculties = context.Faculties.ToList();
            ViewBag.Hobbies = context.Hobbies.ToList();

            return View(facultyHobbyVM);
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


            return LocalRedirect("/admin/Teacher/Index");
        }

        public IActionResult UpdateFacultyHobby(int Tid)
        {
            ViewBag.Faculty = context.Faculties.ToList();
            ViewBag.Hobby = context.Hobbies.ToList();

            ViewBag.TeacherFaculty = context.TeacherFaculties.Where(x=>x.TeacherId==Tid).ToList();
            ViewBag.TeacherHobby = context.TeacherHobbies.Where(x => x.TeacherId == Tid).ToList();
            FacultyHobbyVM facultyHobby = new FacultyHobbyVM()
            {
                TeacherId = Tid
            };


            return View(facultyHobby);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFacultyHobby(FacultyHobbyVM facultyHobbyVM)
        {
            if (!ModelState.IsValid) return View();

            List<TeacherFaculty> teacherFaculties = context.TeacherFaculties.Where(x => x.TeacherId == facultyHobbyVM.TeacherId).ToList();
            context.TeacherFaculties.RemoveRange(teacherFaculties);
            List<TeacherHobby> teacherHobbies = context.TeacherHobbies.Where(x => x.TeacherId == facultyHobbyVM.TeacherId).ToList();
            context.TeacherHobbies.RemoveRange(teacherHobbies);

            foreach (var item in facultyHobbyVM.FacultyIds)
            {
                TeacherFaculty teacherFaculty = new TeacherFaculty()
                {
                    TeacherId = facultyHobbyVM.TeacherId,
                    FacultyId = item
                };

                context.TeacherFaculties.Add(teacherFaculty);
            }

            foreach (var item in facultyHobbyVM.HobbyIds)
            {
                TeacherHobby teacherHobby = new TeacherHobby()
                {
                    TeacherId = facultyHobbyVM.TeacherId,
                    HobbyId = item
                };

                context.TeacherHobbies.Add(teacherHobby);
            }

            await context.SaveChangesAsync();

            return LocalRedirect("/admin/Teacher/Index");
        }

        #endregion

    } 
}
