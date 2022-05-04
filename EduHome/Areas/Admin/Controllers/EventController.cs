using EduHome.Extensions;
using EduHome.Models;
using EduHome.Models.DbTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private readonly MyContext context;
        private readonly IWebHostEnvironment webHost;

        public EventController(MyContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }
        #region Event CRUD

        public IActionResult Index(int page=1)
        {
            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = Math.Ceiling((decimal)context.Events.Count() / 3);
            List<Event> events = context.Events.Skip((page - 1) * 3).Take(3).ToList();
            return View(events);
        }

        public IActionResult CreateEvent()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(Event eventt)
        {
            if (!ModelState.IsValid) return View();

            if (!eventt.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "image type is not Correct");
                return View();
            }

            string folder = @"img\event\";
            eventt.İmage = eventt.Photo.SavaAsync(webHost.WebRootPath, folder).Result;
            context.Events.Add(eventt);
            await context.SaveChangesAsync();


            return LocalRedirect("/admin/Event/index");
        }

        public IActionResult UpdateEvent(int id)
        {
            Event eventt = context.Events.FirstOrDefault(x => x.id == id);
            if (eventt == null) return NotFound();

            return View(eventt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEvent(Event eventt)
        {
            if (!ModelState.IsValid) return View(eventt);
            Event existEvent = context.Events.FirstOrDefault(x => x.id == eventt.id);
            if (existEvent == null) return NotFound();

            if (eventt.Photo != null)
            {
                try
                {
                    string folder = @"img\event\";
                    string newImg = await eventt.Photo.SavaAsync(webHost.WebRootPath, folder);
                    FileExtension.Delete(webHost.WebRootPath, folder, existEvent.İmage);
                    existEvent.İmage = newImg;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "unexpected error for Update");
                    return View();
                }

            }
            existEvent.Day = eventt.Day;
            existEvent.Month = eventt.Month;
            existEvent.Title = eventt.Title;
            existEvent.Description = eventt.Description;
            existEvent.Date = eventt.Date;
            existEvent.Location = eventt.Location;

            context.SaveChanges();
            return LocalRedirect("/admin/event/index");
        }

        public IActionResult DeleteEvent(int id)
        {
            Event existevent = context.Events.FirstOrDefault(x => x.id == id);
            if (existevent == null) return NotFound();
            List<EventSpeaker> eventSpeakers = context.EventSpeakers.Where(x => x.Eventid == id).ToList();

            if (eventSpeakers != null)
                context.EventSpeakers.RemoveRange(eventSpeakers);
           
            string folder = @"img\event\";
            FileExtension.Delete(webHost.WebRootPath, folder, existevent.İmage);
            context.Events.Remove(existevent);
            context.SaveChanges();
            return LocalRedirect("/admin/event/index");
        }
        #endregion

        #region Speaker
        public IActionResult Speaker()
        {
            List<Speaker> speakers = context.Speakers.ToList();

            return View(speakers);
        }

        public IActionResult CreateSpeaker()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpeaker(Speaker speaker)
        {
            if (!ModelState.IsValid) return View();

            if (!speaker.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "image type is not Correct");
                return View();
            }

            string folder = @"img\event\";
            speaker.İmage = speaker.Photo.SavaAsync(webHost.WebRootPath, folder).Result;
            context.Speakers.Add(speaker);
            await context.SaveChangesAsync();


            return LocalRedirect("/admin/Event/Speaker");
        }


        public IActionResult UpdateSpeaker(int id)
        {
            Speaker speaker = context.Speakers.FirstOrDefault(x => x.id == id);
            if (speaker == null) return NotFound();
            return View(speaker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSpeaker(Speaker speaker)
        {
            if (!ModelState.IsValid) return View();
            Speaker existSpeaker = context.Speakers.FirstOrDefault(x => x.id == speaker.id);


            if (speaker.Photo != null)
            {
                try
                {
                    string folder = @"img\event\";
                    string newImg = await speaker.Photo.SavaAsync(webHost.WebRootPath, folder);
                    FileExtension.Delete(webHost.WebRootPath, folder, existSpeaker.İmage);
                    existSpeaker.İmage = newImg;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "unexpected error for Update");
                    return View();
                }

            }
            existSpeaker.Fullname = speaker.Fullname;
            existSpeaker.Responsibility = speaker.Responsibility;
            await context.SaveChangesAsync();
            return LocalRedirect("/admin/Event/Speaker");
        }

        public async Task<IActionResult> DeleteSpeaker(int id)
        {
            Speaker speaker = context.Speakers.FirstOrDefault(x => x.id == id);

            if (speaker == null) return NotFound();
                context.Speakers.Remove(speaker);

            string folder = @"img\event\";
            FileExtension.Delete(webHost.WebRootPath, folder, speaker.İmage);
            context.Speakers.Remove(speaker);
            await context.SaveChangesAsync();

            return LocalRedirect("/admin/Event/Speaker");
        }

        #endregion
    }
}
