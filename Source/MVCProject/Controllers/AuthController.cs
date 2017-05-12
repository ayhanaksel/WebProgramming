using MVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProject.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(AuthLogin form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            FormsAuthentication.SetAuthCookie(form.UserName, true);

            return Content("Hi " + form.UserName);
        }
    }
}