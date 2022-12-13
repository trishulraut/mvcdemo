using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcdemo.Data;

namespace mvcdemo.Models
{
    public class denoModel
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAIL { get; set; }


        public string Savemvcdemo(MVCdemoModel model)
        {
            string Message = "";
            mvcdemoEntities db = new mvcdemoEntities();
            var getCatData = db.tbl_mvcdemo.Where(p => p.ID == model.ID).FirstOrDefault();
            if (getCatData == null)
            {
                var savemvcdemo = new tbl_mvcdemo()
                {
                    ID = model.ID,
                    NAME = model.NAME,
                    MOBILE_NO = model.MOBILE_NO,
                    EMAIL = model.EMAIL,
                };
                db.tbl_mvcdemo.Add(savemvcdemo);
                db.SaveChanges();
                Message = " Added Sucessfully";
                return Message;
            }
            else
            {

                getCatData.NAME = model.NAME;
                getCatData.MOBILE_NO = model.MOBILE_NO;
                getCatData.EMAIL = model.EMAIL;

            };

            db.SaveChanges();
            Message = "Updated Sucessfully";

            return Message;
        }

    }
}