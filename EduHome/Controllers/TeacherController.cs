using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly MyContext db;
        public TeacherController(MyContext context)
        {
            db = context;
        }



        public async Task<IActionResult> Teacher()
        {
           List<EduHome.Models.DbTables.Teacher> teacher =  db.Teachers.Include(c=>c.Contacts).ToList();
            return View(teacher);
        }
    }
}
