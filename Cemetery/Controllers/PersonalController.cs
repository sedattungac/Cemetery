﻿using Cemetery.Business.Concrete;
using Cemetery.DataAccess.Concrete;
using Cemetery.DataAccess.EntityFramework;
using Cemetery.Entity.Entity;
using Cemetery.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cemetery.Controllers
{
    public class PersonalController : Controller
    {
        PersonalManager personalManager = new PersonalManager(new EfPersonalDal());
        Context context = new Context();
        public IActionResult Index()
        {
            var values = personalManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(PersonalViewModel personal)
        {
            Personal p = new Personal();
            if (personal.ImageUrl != null)
            {
                var extension = Path.GetExtension(personal.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Personal", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                personal.ImageUrl.CopyTo(stream);
                p.ImageUrl = "/Images/Personal/" + newimagename;
            }
            p.FullName = personal.FullName;
            p.Telephone = personal.Telephone;
            personalManager.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var valueId = personalManager.TGetById(id);
            return View(valueId);
        }
        [HttpPost]
        public IActionResult Edit(Personal personal, PersonalViewModel viewModel)
        {
            var personalValue = context.Personals.Find(personal.PersonalId);
            if (viewModel.ImageUrl != null)
            {
                var extension = Path.GetExtension(viewModel.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Personal", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                viewModel.ImageUrl.CopyTo(stream);
                personal.ImageUrl = "/Images/Personal/" + newimagename;
                personalManager.TUpdate(personal);
                return RedirectToAction("Index");
            }
            else
            {
                personalValue.FullName = personal.FullName;
                personalValue.Telephone = personal.Telephone;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
        }
        public IActionResult Delete(int id)
        {
            var valueId = personalManager.TGetById(id);
            personalManager.TDelete(valueId);
            return RedirectToAction("Index");
        }
    }
}
