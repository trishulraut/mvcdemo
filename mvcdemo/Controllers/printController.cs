using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcdemo.Data;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    public class printController : Controller
    {
        // GET: print
        public ActionResult Index()
        {
            return View();
        }
    }
}