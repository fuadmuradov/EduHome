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
            context.SaveChangesAsync();
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

    }
}
