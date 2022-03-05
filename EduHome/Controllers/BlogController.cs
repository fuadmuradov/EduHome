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
    public class BlogController : Controller
    {
        private readonly MyContext db;

        public BlogController(MyContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult>  Blogs()
        {
            List<Blog> blogs = await db.Blogs.ToListAsync();

            return View(blogs);
        }

        public async Task<IActionResult> BlogDetails(int? id)
        {
            if (id == null) id = db.Blogs.First().id;

            Models.DbTables.Blog blog = await db.Blogs.FirstOrDefaultAsync(x => x.id == id);

            


            return View(blog);
        }
    }
}
