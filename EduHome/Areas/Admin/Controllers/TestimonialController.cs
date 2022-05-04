using EduHome.Extensions;
using EduHome.Models;
using EduHome.Models.DbTables;
using Microsoft.AspNetCore.Authorization;
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
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly MyContext context;
        private readonly IWebHostEnvironment webHost;

        public TestimonialController(MyContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }

        #region Testimonials Crud
        public IActionResult Index()
        {
            Testimional testimional = context.Testimionals.FirstOrDefault();
            if (testimional == null) return NotFound();
            return View(testimional);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Testimional testimional)
        {
            if (!ModelState.IsValid)
            {
                return View(testimional);
            }

            Testimional existTestimonial = await context.Testimionals.FirstAsync();

            if (testimional.Photo != null)
            {
                try
                {
                    string folder = @"img\testimonial\";
                    string newImg = await testimional.Photo.SavaAsync(webHost.WebRootPath, folder);
                    FileExtension.Delete(webHost.WebRootPath, folder, existTestimonial.Image);
                    existTestimonial.Image = newImg;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "unexpected error for Update");
                    return View();
                }

            }
            existTestimonial.Fullname = testimional.Fullname;
            existTestimonial.Description = testimional.Description;
            existTestimonial.Responsibility = testimional.Responsibility;
            await context.SaveChangesAsync();


            return LocalRedirect("/Admin/Testimonial/index");
        }


        #endregion



    }
}
