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
    [Authorize]
    public class BlogController : Controller
    {
        private readonly MyContext context;
        private readonly IWebHostEnvironment webHost;

        public BlogController(MyContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }

        #region Blog Crud
        public IActionResult Index(int page = 1)
        {
            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = Math.Ceiling((decimal)context.Blogs.Count() / 3);
            List<Blog> blogs = context.Blogs.Skip((page - 1) * 3).Take(3).ToList();
            return View(blogs);
        }

        public IActionResult CreateBlog()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(Blog blog)
        {
            if (!ModelState.IsValid) return View();

            if (!blog.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "image type is not Correct");
                return View();
            }

            string folder = @"img\blog\";
            blog.BlogImage = blog.Photo.SavaAsync(webHost.WebRootPath, folder).Result;
            context.Blogs.Add(blog);
            await context.SaveChangesAsync();


            return LocalRedirect("/admin/Blog/index");
        }

        public IActionResult UpdateBlog(int id)
        {
            Blog blog = context.Blogs.FirstOrDefault(x => x.id == id);
            if (blog == null) return NotFound();

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBlog(Blog blog)
        {
            if (!ModelState.IsValid) return View(blog);
            Blog existBlog = context.Blogs.FirstOrDefault(x => x.id == blog.id);
            if (existBlog == null) return NotFound();

            if (blog.Photo != null)
            {
                try
                {
                    string folder = @"img\blog\";
                    string newImg = await blog.Photo.SavaAsync(webHost.WebRootPath, folder);
                    FileExtension.Delete(webHost.WebRootPath, folder, existBlog.BlogImage);
                    existBlog.BlogImage = newImg;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "unexpected error for Update");
                    return View();
                }

            }
            existBlog.Title = blog.Title;
            existBlog.Description = blog.Description;
            existBlog.Writer = blog.Writer;
            existBlog.Date = blog.Date;

            context.SaveChanges();
            return LocalRedirect("/admin/blog/index");
        }

        public IActionResult DeleteBlog(int id)
        {
            Blog existBlog = context.Blogs.FirstOrDefault(x => x.id == id);
            if (existBlog == null) return NotFound();
            List<Comment> comments = context.Comments.Where(x => x.BlogId == id).ToList();

            if (comments != null)
                context.Comments.RemoveRange(comments);

            string folder = @"img\blog\";
            FileExtension.Delete(webHost.WebRootPath, folder, existBlog.BlogImage);
            context.Blogs.Remove(existBlog);
            context.SaveChanges();
            return LocalRedirect("/admin/blog/index");
        }

        #endregion


    }
}
