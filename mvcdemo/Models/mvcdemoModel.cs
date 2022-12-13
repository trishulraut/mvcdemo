using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcdemo.Data;
using System.Data;
using System.Data.Common;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace mvcdemo.Models
{
    public class MVCdemoModel
    {


        public int ID { get; set; }
        public string NAME { get; set; }
      
        public string MOBILE_NO { get; set; }
     
        public string EMAIL { get; set; }
        public string date { get; set; }

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

        public List<MVCdemoModel> GetMvcdemos()
        {
            mvcdemoEntities db = new mvcdemoEntities();
            List<MVCdemoModel> lstCategory = new List<MVCdemoModel>();
            var mvcdemosd = db.tbl_mvcdemo.ToList();
            if (mvcdemosd != null)
            {
                foreach (var Category in mvcdemosd)
                {

                    string test = DateTime.Now.ToString("dd/MM/yyyy");
                    lstCategory.Add(new MVCdemoModel()
                    {
                        ID = Category.ID,
                        NAME = Category.NAME,
                        MOBILE_NO = Category.MOBILE_NO,
                        EMAIL = Category.EMAIL,
                        date= test

                    });
                }
            }
            return lstCategory;
        }

        public string deletemvc(int Id)
        {
            string Message = "";
            mvcdemoEntities Db = new mvcdemoEntities();
            var deleteRecord = Db.tbl_mvcdemo.Where(p => p.ID == Id).FirstOrDefault();
            if (deleteRecord != null)
            {
                Db.tbl_mvcdemo.Remove(deleteRecord);
            };
            Db.SaveChanges();
            Message = "Record Deleted Successfully";
            return Message;
        }

        public MVCdemoModel EditData(int Id)
        {
            string Message = "";
            MVCdemoModel model = new MVCdemoModel();
            mvcdemoEntities Db = new mvcdemoEntities();
            var editData = Db.tbl_mvcdemo.Where(p => p.ID == Id).FirstOrDefault();
            if (editData != null)
            {
                model.ID = editData.ID;
                model.NAME = editData.NAME;
                model.MOBILE_NO = editData.MOBILE_NO;
                model.EMAIL = editData.EMAIL;
            }

            Message = "Record Deleted Successfully";
            return model;
        }




        public List<MVCdemoModel> SearchCustomer(string Prefix)
        {
            try
            {
                List<MVCdemoModel> model = new List<MVCdemoModel>();
                mvcdemoEntities db = new mvcdemoEntities();
                DataTable dtTable = new DataTable();
                using (var cmd = db.Database.Connection.CreateCommand())
                {
                    try
                    {
                        db.Database.Connection.Open();
                        cmd.CommandText = "usp_GetSearch";
                        cmd.CommandType = CommandType.StoredProcedure;

                        DbParameter LID = cmd.CreateParameter();
                        LID.ParameterName = "SearchString";
                        LID.Value = Prefix;
                        cmd.Parameters.Add(LID);

                        DbDataAdapter da = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dtTable);
                        db.Database.Connection.Close();

                        foreach (DataRow dr in dtTable.Rows)
                        {                         
                            model.Add(new MVCdemoModel()
                            {
                                ID = Convert.ToInt32(dr["ID"].ToString()),
                                NAME = dr["NAME"].ToString(),
                                MOBILE_NO = dr["MOBILE_NO"].ToString(),
                                // SalePrice = (createdDate.HasValue ? createdDate.Value.ToString("MM/dd/yyyy") : ""),
                               
                            });
                        }


                    }
                    catch
                    {
                        db.Database.Connection.Close();
                    }
                }
                db.Dispose();
                return model.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<MVCdemoModel> GetRegistrationList(string NAME)
        {
            mvcdemoEntities db = new mvcdemoEntities();
            List<MVCdemoModel> str = new List<MVCdemoModel>();
            var RegistrationList = db.tbl_mvcdemo.Where(p => p.NAME == NAME).ToList();
            if (RegistrationList != null)
            {
                foreach (var reg in RegistrationList)
                {
                    str.Add(new MVCdemoModel()
                    {
                        ID = reg.ID,
                        NAME = reg.NAME,
                        MOBILE_NO= reg.MOBILE_NO,
                        EMAIL = reg.EMAIL,
                       
                    });
                }
            }
           
            return str;
        }







    }
}