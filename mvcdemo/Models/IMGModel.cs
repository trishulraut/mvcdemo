using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcdemo.Data;
using System.IO;

namespace mvcdemo.Models
{
    public class IMGModel
    {


        public int IMG_ID { get; set; }
        public string NAME { get; set; }
        public string IMG { get; set; }

        public string Saveimg(HttpPostedFileBase fb, IMGModel model)
        {
            string msg = "done";
            mvcdemoEntities db = new mvcdemoEntities();

            string filePath = "";
            string fileName = "";
            string sysFileName = "";
            
           
            if (fb != null && fb.ContentLength > 0)
            {

                //filePath = HttpContext.Current.Server.MapPath("~/Content/Pages/images/");
                filePath = HttpContext.Current.Server.MapPath("~/img/");
                DirectoryInfo di = new DirectoryInfo(filePath);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filePath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/img/") + "/" + sysFileName;

                }
            }
            var getCatData = db.TBL_IMG.Where(p => p.IMG_ID == model.IMG_ID).FirstOrDefault();
            if (getCatData == null)
            {
                var Saveimg = new TBL_IMG()
                {
                    IMG_ID=model.IMG_ID,
                    NAME = model.NAME,
                    IMG = sysFileName,
                };

                db.TBL_IMG.Add(getCatData);
                db.SaveChanges();
                msg = "done";
                return msg;
            }
            else
            {
                getCatData.NAME = model.NAME;
                getCatData.IMG = model.IMG;
            };
            db.SaveChanges();
            msg = "Updated Sucessfully";
            return msg;
        }
    
        public List<IMGModel> DISPLAY()
        {
            mvcdemoEntities db = new mvcdemoEntities();
            List<IMGModel> lstCategory = new List<IMGModel>();
            var mvcdemosd = db.TBL_IMG.ToList();
            if (mvcdemosd != null)
            {
                foreach (var Category in mvcdemosd)
                {
                    lstCategory.Add(new IMGModel()
                    {
                        IMG_ID = Category.IMG_ID,
                        NAME = Category.NAME,
                        IMG = Category.IMG
                    });
                }
            }
            return lstCategory;
        }

        public IMGModel EditData(int Id)
        {
            string msg = "";
            IMGModel model = new IMGModel();
            mvcdemoEntities Db = new mvcdemoEntities();
            var editData = Db.TBL_IMG.Where(p => p.IMG_ID == Id).FirstOrDefault();
            if (editData != null)
            {
                model.IMG_ID = editData.IMG_ID;
                model.NAME = editData.NAME;
                model.IMG = editData.IMG;
            
            }

            msg = "Record edit Successfully";
            return model;
        }


    }


}