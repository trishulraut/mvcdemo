using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    public class validationController : Controller
    {
        // GET: validation
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Savevalidation(validationModel model)

        {
            try
            {

                return Json(new { Message = (new validationModel().Savevalidation(model)) }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }



        }
        public ActionResult Getvalidet()
        {
            try
            {
                return Json(new { model = (new validationModel().Getvalidet()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult deletevalidation(int ID)
        {
            try
            {
                return Json(new { model = (new validationModel().deletevalidation(ID)) }, JsonRequestBehavior.AllowGet);
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
                return Json(new { model = (new validationModel().EditData(ID)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMVCListRazor()
        {
            try

            {
                var model = new validationModel().Getvalidet();
                return View(model);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        public ActionResult create()
        { 
        return View();
        }


    }
}