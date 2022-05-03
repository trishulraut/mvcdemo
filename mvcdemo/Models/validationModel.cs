using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcdemo.Data;
using System.ComponentModel.DataAnnotations;

namespace mvcdemo.Models
{
    public class validationModel
    {


        public int N_ID { get; set; }
        public string NAME { get; set; }
        
        public string AGE { get; set; }
        public string MOBILE { get; set; }
 
        public string EMAIL { get; set; }

        public string Savevalidation(validationModel model)
        {
            string Message = "";
            mvcdemoEntities db = new mvcdemoEntities();
            var getCatData = db.tbl_validater.Where(p => p.N_ID == model.N_ID).FirstOrDefault();
            if (getCatData == null)
            {
                var savevalidation = new tbl_validater()
                {
                    N_ID =model.N_ID,
                    NAME = model.NAME,
                    AGE = model.AGE,
                    MOBILE = model.MOBILE,
                    EMAIL = model.EMAIL

                };
            db.tbl_validater.Add(savevalidation);
            db.SaveChanges();
            Message = "Sucessfully";
            return Message;

            }
            else
            {

                getCatData.NAME = model.NAME;
                getCatData.MOBILE = model.MOBILE;
                getCatData.AGE = model.AGE;
                getCatData.EMAIL = model.EMAIL;

            };

            db.SaveChanges();
            Message = "Updated Sucessfully";

            return Message;
        } 

        public List<validationModel> Getvalidet()
        {
            mvcdemoEntities db = new mvcdemoEntities();
            List<validationModel> lstvalidetE = new List<validationModel>();
            var validet = db.tbl_validater.ToList();
            if (validet != null)
            {
                foreach (var lstvalidet in validet)
                {
                    lstvalidetE.Add(new validationModel()
                    {
                        N_ID = lstvalidet.N_ID,
                        NAME = lstvalidet.NAME,
                        AGE = lstvalidet.AGE,
                        MOBILE = lstvalidet.MOBILE,
                        EMAIL = lstvalidet.EMAIL

                    });
                }
            }
            return lstvalidetE;
        }

        public string deletevalidation(int ID)
        {
            string Message = "";
            mvcdemoEntities Db = new mvcdemoEntities();
            var deleteRecord = Db.tbl_validater.Where(p => p.N_ID == ID).FirstOrDefault();
            if (deleteRecord != null)
            {
                Db.tbl_validater.Remove(deleteRecord);
            };
            Db.SaveChanges();
            Message = "Record Deleted Successfully";
            return Message;
        }


        public validationModel EditData(int Id)
        {
            string Message = "";
            validationModel model = new validationModel();
            mvcdemoEntities Db = new mvcdemoEntities();
            var editData = Db.tbl_validater.Where(p => p.N_ID == Id).FirstOrDefault();
            if (editData != null)
            
            {
                model.N_ID = editData.N_ID;
                model.NAME = editData.NAME;
                model.AGE = editData.AGE;
                model.MOBILE = editData.MOBILE;
                model.EMAIL = editData.EMAIL;
            }

            Message = "Record Deleted Successfully";
            return model;
        }



    }
}