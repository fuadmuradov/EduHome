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


        public async Task<IActionResult> TeacherDetails(int? id)
        {
            Models.DbTables.Teacher teacher = await db.Teachers.Include(c => c.Contacts).Include(s=>s.Skills).Include(f=>f.TeacherFaculties).ThenInclude(fc=>fc.Faculty).Include(hb=>hb.TeacherHobbies).ThenInclude(h=>h.Hobby).FirstOrDefaultAsync(x=>x.id==id);

            return View(teacher);
        }

    }
}
