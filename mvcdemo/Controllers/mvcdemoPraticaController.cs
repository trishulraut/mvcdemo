using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    public class mvcdemoPraticaController : Controller
    {
        // GET: mvcdemoPratica
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Savemvcdemo(MVCdemoModel model)

        {
            try
            {
                return Json(new { Message = (new MVCdemoModel().Savemvcdemo(model)) }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }



        }



    }
}