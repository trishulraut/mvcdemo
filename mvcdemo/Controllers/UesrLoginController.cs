using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using mvcdemo.Data;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    public class UesrLoginController : Controller
    {
        // GET: UesrLogin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin(userlogin model)
        {
            mvcdemoEntities db = new mvcdemoEntities();
            var user = db.userlogins.Where(m => m.Id == model.Id && m.password ==
              model.password).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    Session["UserId"] = user.Id.ToString();
                    Session["FirstName"] = user.username.ToString();
                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    ModelState.AddModelError("", "InvalidUserIdorpassword.");
                }
            }
            return View("..\\employeelogin\\Index", model);
        }
        public ActionResult UserDashBoard()
        {
            if (Session["UserId"] != null)
            {
                ViewBag.UserId = Session["UserId"];
                ViewBag.FirstName = Session["FirstName"];
                return View("..\\Home\\userdash");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View("..\\employeelogin\\Index");
        }
    }
}
