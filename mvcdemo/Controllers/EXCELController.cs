using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using mvcdemo.Models;
using mvcdemo.Data;
using LinqToExcel;//ADD NETGET PACKEAGE FROM SOLUTION EXPORLER
using System.Data.SqlClient;
using OfficeOpenXml;


namespace mvcdemo.Controllers
{
    public class EXCELController : Controller
    {
        // GET: EXCEL

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mvcdemoEntities"].ConnectionString);
        //OleDbConnection Econ;
        private mvcdemoEntities db = new mvcdemoEntities();
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This function is used to download excel format.
        /// </summary>
        /// <param name="Path"></param>
        /// <returns>file</returns>

        public FileResult DownloadExcel()
        {
            string path = "/excelfolder/Users.xlsx";
            return File(path, "application/vnd.ms-excel", "Users.xlsx");
        }

        [HttpPost]
        public JsonResult UploadExcel(tbl_mvcdemo users, HttpPostedFileBase FileUpload)
        {

            List<string> data = new List<string>();
            if (FileUpload != null)
            {
                // tdata.ExecuteCommand("truncate table OtherCompanyAssets");
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = FileUpload.FileName;
                    string targetpath = Server.MapPath("~/excelfolder/");
                    FileUpload.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    var connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                    }

                    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    var ds = new DataSet();
                    adapter.Fill(ds, "ExcelTable");
                    DataTable dtable = ds.Tables["ExcelTable"];
                    string sheetName = "Sheet1";
                    var excelFile = new ExcelQueryFactory(pathToExcelFile);
                    var artistAlbums = from a in excelFile.Worksheet<tbl_mvcdemo>(sheetName) select a;
                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                            if (a.NAME != "" && a.MOBILE_NO != "" && a.EMAIL != "")
                            {
                                tbl_mvcdemo TU = new tbl_mvcdemo();
                                TU.NAME = a.NAME;
                                TU.MOBILE_NO = a.MOBILE_NO;
                                TU.EMAIL = a.EMAIL;
                                db.tbl_mvcdemo.Add(TU);
                                db.SaveChanges();
                            }
                            else
                            {
                                data.Add("<ul>");
                                if (a.NAME == "" || a.NAME == null) data.Add("<li> name is required</li>");
                                if (a.MOBILE_NO == "" || a.MOBILE_NO == null) data.Add("<li> MOBILE is required</li>");
                                if (a.EMAIL == "" || a.EMAIL == null) data.Add("<li>ContactNo is required</li>");
                                data.Add("</ul>");
                                data.ToArray();
                                return Json(data, JsonRequestBehavior.AllowGet);
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {
                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {
                                    Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                                }
                            }
                        }
                    }
                    //deleting excel file from folder
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //alert message for invalid file format
                    data.Add("<ul>");
                    data.Add("<li>Only Excel file format is allowed</li>");
                    data.Add("</ul>");
                    data.ToArray();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                data.Add("<ul>");
                if (FileUpload == null) data.Add("<li>Please choose Excel file</li>");
                data.Add("</ul>");
                data.ToArray();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult Upload(FormCollection formCollection)
        {
            var EXCELModel = new List<EXCELModel>();
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string filename = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    using (var pakage = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = pakage.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCal = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        using (mvcdemoEntities db = new mvcdemoEntities())
                        {
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                var user = new tbl_mvcdemo();
                                user.NAME = workSheet.Cells[rowIterator, 1].Value.ToString();

                                user.MOBILE_NO = workSheet.Cells[rowIterator, 2].Value.ToString();

                                user.EMAIL = workSheet.Cells[rowIterator, 3].Value.ToString();
                                db.tbl_mvcdemo.Add(user);
                                db.SaveChanges();

                            }
                        }

                    }

                }

            }
            return View("Index1");

        }
    }
}