using System;
using System.Collections.Generic;
using System.Web.Mvc;
using web_form_1.Models;

namespace web_form_1.Controllers
{
    public class ReportInfo
    {
        public string ReportName { get; set; }
        public string ReportCode { get; set; }
    }

    public class HomeController : Controller
    {
        public DateTime CURRENT_DATE = DateTime.Today;
        public ActionResult Index() {
            List<web_access> ReportName = web_access.getReportName();
            return View(ReportName);
        }

         public JsonResult GetReportData()
         {
             List<web_access> Report = web_access.getReport();
             List<ReportInfo> res = new List<ReportInfo>();
             foreach (var item in Report)
             {
                 res.Add(new ReportInfo
                 {
                     ReportName = item.NAMA_LAPORAN,
                     ReportCode = item.RPT_CD
                 });
             }

             return Json(res, JsonRequestBehavior.AllowGet);
         } 

        // POST: Remove/Create
        [HttpPost]
        public ActionResult Create(string REPORT_NAME, string RPT_CD, string USER_ID, string NO_EREQUEST)
        {
            try
            {
                List<web_access> new_data = web_access.insertData(REPORT_NAME, RPT_CD,
                  USER_ID, CURRENT_DATE, NO_EREQUEST);

                TempData["msg"] = "<script>alert('Insert Data Success!!');</script>";
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}