using EduHome.Models;
using EduHome.Models.DbTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class LatestBlogViewComponent:ViewComponent
    {
        private readonly MyContext db;

        public LatestBlogViewComponent(MyContext context)
        {
            this.db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Blog> blogs = await db.Blogs.OrderByDescending(x=>x.Date).ToListAsync();

            return View(blogs);
        }
    }
}
