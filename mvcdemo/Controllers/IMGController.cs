using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    public class IMGController : Controller
    {
        // GET: IMG
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Saveimg(IMGModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];

                }
                return Json(new { message = new IMGModel().Saveimg(fb, model) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetDISPLAY()
        {
            try
            {
                return Json(new { model = (new IMGModel().DISPLAY()) }, JsonRequestBehavior.AllowGet);
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
                return Json(new { model = (new IMGModel().EditData(ID)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}