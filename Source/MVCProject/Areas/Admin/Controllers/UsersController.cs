using MVCProject.Areas.Admin.ViewModels;
using MVCProject.Infrastructure;
using MVCProject.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTabAttribute("users")]
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            return View(new UsersIndex
            {
                Users = Database.Session.Query<User>().ToList()
            });
        }
        public ActionResult New()
        {
            return View(new UsersNew
            {

            });
        }
        [HttpPost]
        public ActionResult New(UsersNew form)
        {
            if (Database.Session.Query<User>().Any(u => u.UserName == form.UserName))
                ModelState.AddModelError("UserName", "User Name must be unique");

            if (!ModelState.IsValid)
                return View(form);

            var user = new User
            {
                Email = form.Email,
                UserName = form.UserName
            };

            user.SetPassword(form.Password);

            Database.Session.Save(user);

            return RedirectToAction("Index");
        }
    }
}