using BusinessLayer.Concrete;
using Cemetery.Business.Concrete;
using Cemetery.DataAccess.EntityFramework;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cemetery.ViewComponents.About
{
    public class PersonalList : ViewComponent
    {
        PersonalManager personalManager = new PersonalManager(new EfPersonalDal());

        public IViewComponentResult Invoke()
        {
            var values = personalManager.TGetList();
            return View(values);
        }
    }
}
