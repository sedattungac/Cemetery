using BusinessLayer.Concrete;
using Cemetery.DataAccess.Concrete;
using Cemetery.Entity.Entity;
using Cemetery.Models;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cemetery.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        Context context = new Context();
        public IActionResult Index()
        {
            var values = productManager.GetProductWithProductCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            using Context context = new Context();
            List<SelectListItem> category = (from x in context.ProductCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.ProductCategoryId.ToString()



                                             }).ToList();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            Product p = new Product();
            if (product.ImageUrl != null)
            {
                var extension = Path.GetExtension(product.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                product.ImageUrl.CopyTo(stream);
                p.ImageUrl = "/Images/Product/" + newimagename;
            }
            p.Title = product.Title;
            p.Price = product.Price;
            p.Description = product.Description;
            p.ProductCategoryId = product.ProductCategoryId;

            productManager.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<SelectListItem> category = (from x in context.ProductCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.ProductCategoryId.ToString()



                                             }).ToList();
            ViewBag.category = category;
            var values = productManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Product product, ProductViewModel viewModel)
        {
            var productValue = context.Products.Find(product.ProductId);
            if (viewModel.ImageUrl != null)
            {
                var extension = Path.GetExtension(viewModel.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                viewModel.ImageUrl.CopyTo(stream);
                product.ImageUrl = "/Images/Product/" + newimagename;

                productManager.TUpdate(product);
                return RedirectToAction("Index");

            }
            else
            {
                productValue.Title = product.Title;
                productValue.Description = product.Description;
                //context.Update(product);
                context.SaveChanges();
                return RedirectToAction("Index");

            }

        }
        public IActionResult Delete(int id)
        {
            var valueId = productManager.TGetById(id);
            productManager.TDelete(valueId);
            //System.IO.File.Delete("wwwroot/" + valueId.ImageUrl);
            return RedirectToAction("Index");
        }
    }
}
