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
    public class CategoryViewComponent:ViewComponent
    {
        private readonly MyContext db;

        public CategoryViewComponent(MyContext context)
        {
            this.db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await db.Categories.ToListAsync();

            return View(categories);
        }
    }
}
