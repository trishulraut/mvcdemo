using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using mvcdemo.Models;
using mvcdemo.Data;
namespace mvcdemo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginIN(loginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "Admin" && model.Password == "trishul@123")
                {

                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name or password.");
                }

            }
            return View("..\\Login\\Index", model);
        }

        public ActionResult UserDashBoard()
        {
            //return View("..\\Login\\Index");
            return View("..\\mvcdemo\\Index");
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View("..\\Login\\Index");
        }
    }
}