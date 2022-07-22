using BusinessLayer.Concrete;
using Cemetery.Entity.Entity;
using Cemetery.Models;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cemetery.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        [HttpGet]
        public IActionResult Index(int id=1)
        {
            var valueId = adminManager.TGetById(id);
            return View(valueId);
        }
        [HttpPost]
        public IActionResult Index(Admin admin)
        {
            adminManager.TUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}
