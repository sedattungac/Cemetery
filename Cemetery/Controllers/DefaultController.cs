using BusinessLayer.Concrete;
using Cemetery.Business.Concrete;
using Cemetery.DataAccess.Concrete;
using Cemetery.DataAccess.EntityFramework;
using Cemetery.Entity.Entity;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cemetery.Controllers
{
    public class DefaultController : Controller
    {
        ProductCategoryManager productCategoryManager = new ProductCategoryManager(new EfProductCategoryDal());
        ProductManager productManager = new ProductManager(new EfProductDal());
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        PersonalManager personalManager = new PersonalManager(new EfPersonalDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());
        Context context = new Context();
        public IActionResult Index()
        {
            var values = productCategoryManager.TGetList();
            return View(values);
        }
        public IActionResult Products(int id)
        {
            var values = context.Products.Include(x => x.ProductCategory).Where(x => x.ProductCategory.ProductCategoryId == id).OrderByDescending(x => x.ProductId).ToList();
            return View(values);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Personal()
        {
            var value = personalManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Contact contact)
        {
            contactManager.TAdd(contact);
            return RedirectToAction("Contact");
        }
    }
}
