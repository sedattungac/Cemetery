using Cemetery.Business.Concrete;
using Cemetery.DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cemetery.Controllers
{
    public class PersonalController : Controller
    {
        PersonalManager personalManager = new PersonalManager(new EfPersonalDal());
        public IActionResult Index()
        {
            var values = personalManager.TGetList();
            return View(values);
        }
    }
}
