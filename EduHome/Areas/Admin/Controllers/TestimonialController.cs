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
    public class TestimonialController : Controller
    {
        private readonly MyContext context;
        private readonly IWebHostEnvironment webHost;

        public TestimonialController(MyContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }

        #region Blog Crud
        public IActionResult Index()
        {
            Testimional testimional = context.Testimionals.FirstOrDefault();
            if (testimional == null) return NotFound();
            return View(testimional);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(Testimional testimional)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(about);
        //    }

        //    Testimional existTestimonial = await context.Testimionals.FirstAsync();

        //    if (about.Photo != null)
        //    {
        //        try
        //        {
        //            string folder = @"img\about\";
        //            string newImg = await about.Photo.SavaAsync(webHost.WebRootPath, folder);
        //            FileExtension.Delete(webHost.WebRootPath, folder, existAbout.Image);
        //            existAbout.Image = newImg;
        //        }
        //        catch (Exception e)
        //        {
        //            ModelState.AddModelError("", "unexpected error for Update");
        //            return View();
        //        }

        //    }
        //    existAbout.Title = about.Title;
        //    existAbout.Description = about.Description;
        //    await context.SaveChangesAsync();


        //    return LocalRedirect("/Admin/Home/About");
        //}


        #endregion



    }
}
