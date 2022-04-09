using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_form_1.Models;

namespace web_form_1.Controllers
{
    public class RemoveController : Controller
    {

        // GET: All Data
        public ActionResult Index(int? page)
        {
            List<web_access> AllData = web_access.getData();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(AllData.ToPagedList(pageNumber, pageSize));
        }

        // GET: Search Data
        public ActionResult Search(string TABLE_SEARCH, int? page)
        {
            List<web_access> SearchData = web_access.searchData(TABLE_SEARCH);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View("Index", SearchData.ToPagedList(pageNumber, pageSize));
        }

        // POST: Remove/Delete
        [HttpPost]
        public ActionResult Delete(string RPT_CD, string USER_ID)
        {
            try
            {
                List<web_access> Delete_Data = web_access.deleteData(RPT_CD, USER_ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
