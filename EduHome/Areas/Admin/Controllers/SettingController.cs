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
    public class SettingController : Controller
    {
        private readonly MyContext context;
        private readonly IWebHostEnvironment webHost;

        public SettingController(MyContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }

        public IActionResult Index()
        {
            Setting setting = context.Settings.First();
            if (setting == null) return NotFound();

                return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return View(setting);
            }

            Setting existSetting = await context.Settings.FirstAsync();

            if (setting.Photo != null)
            {
                try
                {
                    string folder = @"img\logo\";
                    string newImg = await setting.Photo.SavaAsync(webHost.WebRootPath, folder);
                    FileExtension.Delete(webHost.WebRootPath, folder, existSetting.Logo);
                    existSetting.Logo = newImg;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "unexpected error for Update");
                    return View();
                }

            }
            existSetting.Address = setting.Address;
            existSetting.phone1 = setting.phone1;
            existSetting.phone2 = setting.phone2;
            existSetting.Description = setting.Description;
            existSetting.Mail = setting.Mail;
            existSetting.WebSite = setting.WebSite;
            await context.SaveChangesAsync();


            return LocalRedirect("/Admin/Testimonial/index");
        }

    }
}
