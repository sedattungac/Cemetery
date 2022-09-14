using BusinessLayer.Concrete;
using Cemetery.DataAccess.Concrete;
using Cemetery.Entity.Entity;
using Cemetery.Models;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cemetery.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        Context context = new Context();

        [HttpGet]
        public IActionResult Index(int id = 1)
        {
            var valueId = aboutManager.TGetById(id);
            ViewBag.image = valueId.ImageUrl;
            return View(valueId);
        }
        [HttpPost]
        public IActionResult Index(About about, AboutViewModel viewModel)
        {
            var aboutValue = context.Abouts.Find(about.AboutId);
            if (viewModel.ImageUrl != null)
            {
                var extension = Path.GetExtension(viewModel.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/About", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                viewModel.ImageUrl.CopyTo(stream);
                about.ImageUrl = "/Images/About/" + newimagename;
                aboutManager.TUpdate(about);
                return RedirectToAction("Index");
            }
            else
            {
                aboutValue.Title = about.Title;
                aboutValue.Description = about.Description;
                aboutValue.Description2 = about.Description2;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }
}
