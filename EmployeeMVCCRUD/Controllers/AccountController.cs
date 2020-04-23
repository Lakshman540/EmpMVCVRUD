using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeMVCCRUD.Models;
using System.Web.Security;

namespace EmployeeMVCCRUD.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var context = new OfficeEntities())
            {
                bool isValid = context.Users.Any(x=>x.UserName==model.Username&&x.Password==model.Password);
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Username,false);
                    return RedirectToAction("Index","Employees");
                }
                ModelState.AddModelError("","Invalid UserName or Password");
            }
                return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User model)
        {
            using (var context = new OfficeEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }

}