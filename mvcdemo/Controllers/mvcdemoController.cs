
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    public class mvcdemoController : Controller
    {
        // GET: mvcdemo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult search()
        {
            return View();
        }

        public ActionResult searchopration()
        {
            return View();
        }
        public ActionResult voice()
        {
            return View();
        }




        public ActionResult Savemvcdemo(mvcdemoModel model)

        {
            try
            {
                return Json(new { Message = (new mvcdemoModel().Savemvcdemo(model)) }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }



        }
        public ActionResult GetMvcdemos()
        {
            try
            {
                return Json(new { model = (new mvcdemoModel().GetMvcdemos()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult deletemvc(int Id)
        {
            try
            {
                return Json(new { model = (new mvcdemoModel().deletemvc(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }


        public ActionResult GetEditData(int ID)
        {

            try
            {
                return Json(new { model = (new mvcdemoModel().EditData(ID)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetRegistrationList(string CompanyName)
        {
            try
            {
                return Json(new { model = (new mvcdemoModel().GetRegistrationList(CompanyName)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }





    }
}