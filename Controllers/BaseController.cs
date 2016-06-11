using IndianCitizenService.Common;
using IndianCitizenService.Handler;
using IndianCitizenService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace IndianCitizenService.Controllers
{


    public class BaseController : Controller
    {
        private static IList<VoteDetail> voteCollection;
        private static LocationDetail locationDetail;
        private static bool IsRoadCleaned;
        public BaseController()
        {
            if (voteCollection == null)
                voteCollection = new List<VoteDetail>();
            if(locationDetail == null)
            locationDetail = new LocationDetail()
            {
                Id = 1,
                LocLalitudeStart = 13.02804601720666,
                LocLalitudeEnd = 80.17689228057861,
                LocLongitudeStart = 13.029739344613546,
                LocLongitudeEnd = 80.17709612846375
            };
            
        }
        //
        // GET: /Base/
        public ActionResult Index()
        {
            ViewBag.Notification = IsRoadCleaned;
            return View();
        }

        public ActionResult LiveMap()
        {
            LiveTrackHandler handler = new LiveTrackHandler();
            var detail = handler.getVoteDetail(voteCollection);
            return View(detail);
        }

        public ActionResult Logon()
        {
            return View();
        }

        public ActionResult VoteAction(int selectedCategory)
        {
            VoteDetail renderDetail = new VoteDetail()
            {
                LocationDetail= locationDetail,
                GradeValue = LiveTrackHandler.getGrade(selectedCategory),
                Id = 20
            };
            voteCollection.Add(renderDetail);
            if (IsRoadCleaned) { 
                IsRoadCleaned = false;
            }
            return Json(true);
        }

        public ActionResult SaveStatus()
        {
            IsRoadCleaned = true;
            return Json(null);
        }

        public ActionResult ValidateUser(string userId, string password)
        {
            if ((userId.Equals(AppConstant.CitizenUserId) || userId.Equals(AppConstant.CitizenUserId1)  || userId.Equals(AppConstant.CitizenUserId) ) && password.Equals(AppConstant.CitizenPassword))
            {
                return Json(AppConstant.HostName + AppConstant.BaseController + AppConstant.FileHash.ToString() + AppConstant.ViewUserMap);

            }
            else if (userId.Equals(AppConstant.AdminUserID) && password.Equals(AppConstant.AdminPassword))
                return Json(AppConstant.HostName + AppConstant.BaseController + AppConstant.FileHash.ToString() + AppConstant.ViewLiveMap);
            else
                return Json(false);
        }

        public ActionResult ReportIndex(int? reportType)
        {

            return View(reportType);
        }

        public ActionResult PieChart()
        {
            var key = new Chart(width: 600, height: 400)
              .AddSeries(
                  chartType: "pie",
                  legend: "City Health Status",
                  xValue: new[] { "Low", "Medium", "High", "Concern free" },
                  yValues: new[] { "2", "28", "30", "40" })


              .Write();

            return null;
        }

        public ActionResult BarChart()
        {
            var key = new Chart(width: 600, height: 400)
                  .AddSeries(
                      chartType: "bar",
                      legend: "City Health Status",
                      xValue: new[] { "High", "Medium", "Low", "Concern free" },
                      yValues: new[] { "30", "28", "2", "40" })
                  .Write();

            return null;
        }

        public ActionResult AreawiseChart()
        {
            var key = new Chart(width: 600, height: 400)
              .AddSeries(
                  chartType: "bar",
                  legend: "City Health Status",
                  yValues: new[] { "22", "28", "30", "20" },
                  xValue: new[] { "Guindy", "Nandambakkam", "Manapakkam", "Porur" })


              .Write();

            return null;
        }

        public ActionResult CityWise()
        {
            var key = new Chart(width: 600, height: 400)
              .AddSeries(
                  chartType: "bar",
                  legend: "City Health Status",
                  xValue: new[] { "Chennai", "Bangalore", "Hyderabad", "Mumbai" },
                  yValues: new[] { "32", "28", "20", "20" })


              .Write();

            return null;
        }

    }
}
