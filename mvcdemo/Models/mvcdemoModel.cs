using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcdemo.Data;
using System.Data;
using System.Data.Common;
using System.Web.Mvc;


namespace mvcdemo.Models
{
    public class mvcdemoModel
    {


        public int ID { get; set; }
        public string NAME { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAIL { get; set; }

        public string Savemvcdemo(mvcdemoModel model)
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

        public List<mvcdemoModel> GetMvcdemos()
        {
            mvcdemoEntities db = new mvcdemoEntities();
            List<mvcdemoModel> lstCategory = new List<mvcdemoModel>();
            var mvcdemosd = db.tbl_mvcdemo.ToList();
            if (mvcdemosd != null)
            {
                foreach (var Category in mvcdemosd)
                {
                    lstCategory.Add(new mvcdemoModel()
                    {
                        ID = Category.ID,
                        NAME = Category.NAME,
                        MOBILE_NO = Category.MOBILE_NO,
                        EMAIL = Category.EMAIL

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

        public mvcdemoModel EditData(int Id)
        {
            string Message = "";
            mvcdemoModel model = new mvcdemoModel();
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




        public List<mvcdemoModel> SearchCustomer(string Prefix)
        {
            try
            {
                List<mvcdemoModel> model = new List<mvcdemoModel>();
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
                            model.Add(new mvcdemoModel()
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


        public List<mvcdemoModel> GetRegistrationList(string NAME)
        {
            mvcdemoEntities db = new mvcdemoEntities();
            List<mvcdemoModel> str = new List<mvcdemoModel>();
            var RegistrationList = db.tbl_mvcdemo.Where(p => p.NAME == NAME).ToList();
            if (RegistrationList != null)
            {
                foreach (var reg in RegistrationList)
                {
                    str.Add(new mvcdemoModel()
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