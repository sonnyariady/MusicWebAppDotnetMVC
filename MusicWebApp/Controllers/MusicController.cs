using MusicWebApp.Library;
using MusicWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWebApp.Controllers
{
    public class MusicController : Controller
    {
        //
        // GET: /Music/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            WebAPIRequest req = new WebAPIRequest();
            string url = "api/Artist";
            ResponseGetViewModel resp = req.RequestDelete(url, "id=" + id);
            string hasilresp = resp.HasilRespon;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            WebAPIRequest req = new WebAPIRequest();
            string url = "api/Artist";
            ResponseGetViewModel resp = req.RequestGet(url, "id=" + id);
            Artist result = JsonConvert.DeserializeObject<Artist>(resp.HasilRespon);
            return View(result);
        }

        public ActionResult ViewPlay(int id)
        {
            WebAPIRequest req = new WebAPIRequest();
            string url = "api/Artist";
            ResponseGetViewModel resp = req.RequestGet(url, "id=" + id);
            Artist result = JsonConvert.DeserializeObject<Artist>(resp.HasilRespon);
            return PartialView(result);
        }

        public ActionResult Create()
        {
            Artist obj = new Artist();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(Artist input)
        {
            WebAPIRequest req = new WebAPIRequest();
            string jsonstring = JsonConvert.SerializeObject(input);
            string url = "api/Artist/" + input.ArtistID;
            ResponseGetViewModel resp = req.RequestPut(url, jsonstring);
            if (!string.IsNullOrWhiteSpace(resp.ErrorMessage))
            {
                return Content("Error: " + resp.ErrorMessage);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Create(Artist input)
        {
            WebAPIRequest req = new WebAPIRequest();
            string jsonstring = JsonConvert.SerializeObject(input);
            string url = "api/Artist";
            ResponseGetViewModel resp = req.RequestPost(url, jsonstring);
            if (!string.IsNullOrWhiteSpace(resp.ErrorMessage))
            {
                return Content("Error: " + resp.ErrorMessage);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult MusicAjaxHandler(JQueryDataTableParamModel param)
        {
            List<ArtistViewModel> listdata = new List<ArtistViewModel>();
            try
            {
                //if (!CustomHttpApplication.HasPrivilage)
                //{
                //    return RedirectToAction("NotAuthorized");
                //}
                //Expression<Func<DsfUserInfo, bool>> filter = null;

                ////Search Criteria
                //filter = (c => ((EmpName != "" ? c.EmpName.Contains(EmpName) : c.IsDelete.Equals(false))
                //                                && (UserId != "" ? c.UserId.Contains(UserId) : c.IsDelete.Equals(false))
                //                                && (AdUserId != "" ? c.AdUserId.Contains(AdUserId) : c.IsDelete.Equals(false))
                //                                && (BranchName != "" ? c.BranchName.Contains(BranchName) : c.IsDelete.Equals(false))
                //                                && ((Status != "" && Status != "All") ? c.IsRegistered.Equals(Status) : c.IsDelete.Equals(false))
                //                                && (Email != "" ? c.Email.Contains(Email) : c.IsDelete.Equals(false))));

                //#region Set Sorting & Ordering

                //var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                //Expression<Func<DsfUserInfo, string>> ordering = (c => sortColumnIndex == 0
                //    ? c.UserId
                //    : sortColumnIndex == 1
                //        ? c.AdUserId
                //       : sortColumnIndex == 2
                //            ? c.EmpName
                //        : sortColumnIndex == 3
                //            ? c.BranchName
                //            : sortColumnIndex == 4
                //                ? c.Email
                //                : c.IsRegistered
                //    );

                //var sortDirection = Request["sSortDir_0"]; // asc or desc

                //#endregion

                //var data = _userService.GetDsfUserList(filter, param.iDisplayLength, param.iDisplayStart, ordering, sortDirection);

              WebAPIRequest req = new WebAPIRequest();
            string url = "api/Artist";
            ResponseGetViewModel resp = req.RequestGet(url, "");
            listdata = JsonConvert.DeserializeObject<List<ArtistViewModel>>(resp.HasilRespon);

                foreach (ArtistViewModel item in listdata)
                {
                    item.ReleaseDateStr = item.ReleaseDate.ToString("dd MMM yyyy");
                }

                //listdata = 

                //var result = from c in data
                //             select new
                //             {
                //                 c.UserId,
                //                 c.AdUserId,
                //                 c.OfficeId,
                //                 c.EmpName,
                //                 c.BranchName,
                //                 c.PositionName,
                //                 c.Email,
                //                 c.ActiveFlag,
                //                 c.IsRegistered,
                //                 BtnAction = c.ActiveFlag
                //             };

                // Return Json
                return Json(new
                {
                    param.sEcho,
                    iTotalRecords = listdata.Count(),
                    iTotalDisplayRecords = listdata.Count(),
                    aaData = listdata.ToList()
                },

                JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //Tracer.Error(ex.ToString());
                return View("Error");
            }
        }

        

    }
}
