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
    public class EventController : Controller
    {
        private readonly MyContext db;
        public EventController(MyContext context)
        {
            db = context;
        }

        public async Task<IActionResult>  EventHome()
        {
            List<Event> events =await db.Events.Include(es=>es.EventSpeakers).ToListAsync();
            return View(events);
        }

        public async Task<IActionResult> EventDetails(int ? id)
        {
            if (id == null) id = db.Events.First().id;

            Models.DbTables.Event dbevent = await db.Events.Include(sp=>sp.EventSpeakers).ThenInclude(spk=>spk.Speaker).FirstOrDefaultAsync(x => x.id == id);

            if (dbevent == null)
            {
                return NotFound();
            }


            return View(dbevent);
        }
    }
}
