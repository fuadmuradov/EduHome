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
    public class ContactController : Controller
    {
        private readonly MyContext context;

        public ContactController(MyContext context)
        {
            this.context = context;
        }
        public IActionResult Contacts()
        {
            return View();
        }
       [HttpPost]
       public async Task<IActionResult> Contacts(Notification notification)
        {
            if (!ModelState.IsValid) return View();
            context.Notifications.Add(notification);
            await context.SaveChangesAsync();
            return View();
        }

    }
}
