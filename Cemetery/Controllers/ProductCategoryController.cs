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
    public class ProductCategoryController : Controller
    {
        Context context = new Context();
        ProductCategoryManager productCategoryManager = new ProductCategoryManager(new EfProductCategoryDal());
        public IActionResult Index()
        {
            var values = productCategoryManager.TGetList().ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductCategoryViewModel product)
        {
            ProductCategory p = new ProductCategory();
            if (product.ImageUrl != null)
            {
                var extension = Path.GetExtension(product.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/ProductCategory", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                product.ImageUrl.CopyTo(stream);
                p.ImageUrl = "/Images/ProductCategory/" + newimagename;
            }
            p.Title = product.Title;
            p.Description = product.Description;
            productCategoryManager.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var valueId = productCategoryManager.TGetById(id);
            return View(valueId);
        }
        [HttpPost]
        public IActionResult Edit(ProductCategory productCategory, ProductCategoryViewModel viewModel)
        {
            var productValue = context.ProductCategories.Find(productCategory.ProductCategoryId);
            if (viewModel.ImageUrl != null)
            {
                var extension = Path.GetExtension(viewModel.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/ProductCategory", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                viewModel.ImageUrl.CopyTo(stream);
                productCategory.ImageUrl = "/Images/ProductCategory/" + newimagename;
                productCategoryManager.TUpdate(productCategory);
                return RedirectToAction("Index");
            }
            else
            {
                productValue.Title = productCategory.Title;
                productValue.Description = productCategory.Description;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
        }
        public IActionResult Delete(int id)
        {
            var valueId = productCategoryManager.TGetById(id);
            productCategoryManager.TDelete(valueId);
            return RedirectToAction("Index");
        }
    }
}
