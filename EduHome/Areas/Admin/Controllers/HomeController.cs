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
    [Route("admin/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly MyContext context;
        private readonly IWebHostEnvironment webHost;

        public HomeController(MyContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }
        public IActionResult Index()
        {
            Slider slider = context.Sliders.Include(x => x.SliderImages).First();
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Slider slider)
        {
            Slider existSlider = await context.Sliders.FirstAsync();
            if (existSlider == null) return NotFound();
            existSlider.Title = slider.Title;
            existSlider.Description = slider.Description;
            await context.SaveChangesAsync();
            return View();
        }


        #region Slider
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderImage sliderImage)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!sliderImage.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Image Format does not Right");
                return View(sliderImage);
            }

            string folder = @"img\slider\";
            sliderImage.Image = sliderImage.Photo.SavaAsync(webHost.WebRootPath, folder).Result;
            sliderImage.SliderId = context.Sliders.First().id;
            await context.SliderImages.AddAsync(sliderImage);
            await context.SaveChangesAsync();


            return LocalRedirect("/Admin/Home/Index");

        }


//*************************** Edit ***********************************

        public IActionResult Edit(int id)
        {
            SliderImage sliderImage = context.SliderImages.FirstOrDefault(x => x.id == id);
            if (sliderImage == null)
            {
                return NotFound();
            }
            return View(sliderImage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SliderImage sliderImage)
        {
            if (!ModelState.IsValid)
            {
                return View(sliderImage);
            }

            SliderImage existSlider = await context.SliderImages.FirstOrDefaultAsync(x => x.id == sliderImage.id);

            if (sliderImage.Photo != null)
            {
                try
                {
                    string folder = @"img\slider\";
                    string newImg = await sliderImage.Photo.SavaAsync(webHost.WebRootPath, folder);
                    FileExtension.Delete(webHost.WebRootPath, folder, existSlider.Image);
                    existSlider.Image = newImg;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "unexpected error for Update");
                    return View();
                }

            }
            existSlider.LineOrdeer = sliderImage.LineOrdeer;

            await context.SaveChangesAsync();


            return LocalRedirect("/Admin/Home/Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            SliderImage slider = await context.SliderImages.FirstOrDefaultAsync(f => f.id == id);

            if (slider == null) return RedirectToAction(nameof(Slider));
            string folder = @"img\slider\";
            FileExtension.Delete(webHost.WebRootPath, folder, slider.Image);
            context.SliderImages.Remove(slider);

            context.SaveChanges();

            return LocalRedirect("/Admin/Home/Index");

        }


        #endregion

        #region Notice

        public IActionResult Notice(int page =1)
        {
            ViewBag.NoticeSecond = context.NoticeSeconds.ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = Math.Ceiling((decimal)context.Notices.Count() / 3);

            List<Notice> notices = context.Notices.Skip((page - 1) * 3).Take(3).ToList();


            return View(notices);
        }

        public IActionResult CreateNotice()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNotice(Notice notice)
        {
            if (!ModelState.IsValid) return View();
            context.Notices.Add(notice);
            await context.SaveChangesAsync();

            return LocalRedirect("/Admin/Home/Notice");
        }

        public IActionResult EditNotice(int id)
        {
            Notice notice = context.Notices.FirstOrDefault(x=>x.id==id);
            if (notice == null) return NotFound();


            return View(notice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNotice(Notice notice)
        {
            if (!ModelState.IsValid) return View();
            Notice existnotice = await context.Notices.FirstOrDefaultAsync(x => x.id == notice.id);
            if (existnotice == null) return NotFound();

            existnotice.Title = notice.Title;
            existnotice.Description = notice.Description;
            await context.SaveChangesAsync();

            return LocalRedirect("/Admin/Home/Notice");
        }

        public async Task<IActionResult> DeleteNotice(int id)
        {
            Notice existnotice = await context.Notices.FirstOrDefaultAsync(x=>x.id==id);
            if (existnotice == null) return NotFound();
            context.Notices.Remove(existnotice);
             await context.SaveChangesAsync();

            return LocalRedirect("/Admin/Home/Notice");
        }

        #endregion


        //******************************* Notice Second ************************************


        #region NoticeSecond

        public IActionResult NoticeSecond(int page = 1)
        {
            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = Math.Ceiling((decimal)context.NoticeSeconds.Count() / 3);

            List<NoticeSecond> noticeseconds = context.NoticeSeconds.Skip((page - 1) * 3).Take(3).ToList();


            return View(noticeseconds);
        }

        public IActionResult CreateNoticeSecond()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNoticeSecond(NoticeSecond notice)
        {
            if (!ModelState.IsValid) return View();
            context.NoticeSeconds.Add(notice);
            await context.SaveChangesAsync();

            return LocalRedirect("/Admin/Home/NoticeSecond");
        }

        public IActionResult EditNoticeSecond(int id)
        {
            NoticeSecond notice = context.NoticeSeconds.FirstOrDefault(x => x.id == id);
            if (notice == null) return NotFound();


            return View(notice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNoticeSecond(NoticeSecond notice)
        {
            if (!ModelState.IsValid) return View();
            NoticeSecond existnotice = await context.NoticeSeconds.FirstOrDefaultAsync(x => x.id == notice.id);
            if (existnotice == null) return NotFound();

            existnotice.Title = notice.Title;
            existnotice.Description = notice.Description;
            await context.SaveChangesAsync();

            return LocalRedirect("/Admin/Home/NoticeSecond");
        }

        public async Task<IActionResult> DeleteNoticeSecond(int id)
        {
            NoticeSecond existnotice = await context.NoticeSeconds.FirstOrDefaultAsync(x => x.id == id);
            if (existnotice == null) return NotFound();
            context.NoticeSeconds.Remove(existnotice);
            await context.SaveChangesAsync();

            return LocalRedirect("/Admin/Home/NoticeSecond");
        }


        #endregion

        #region About

        public IActionResult About()
        {
            About about = context.Abouts.FirstOrDefault();
            if (about == null) return NotFound();
            return View(about);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> About(About about)
        {
            if (!ModelState.IsValid)
            {
                return View(about);
            }

            About existAbout = await context.Abouts.FirstAsync();

            if (about.Photo != null)
            {
                try
                {
                    string folder = @"img\about\";
                    string newImg = await about.Photo.SavaAsync(webHost.WebRootPath, folder);
                    FileExtension.Delete(webHost.WebRootPath, folder, existAbout.Image);
                    existAbout.Image = newImg;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "unexpected error for Update");
                    return View();
                }

            }
            existAbout.Title = about.Title;
            existAbout.Description = about.Description;
            await context.SaveChangesAsync();


            return LocalRedirect("/Admin/Home/About");
        }


        #endregion


    }
}
