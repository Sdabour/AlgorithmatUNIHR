using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlgorithmatMVC.Controllers
{
    public class SingleWorkLocation
    {
        public int ID;
        public string Desc;
        public string CenterLong;
        public string CenterLat;
        public string PointLong;
        public string PoingLat;
    }

    public class LocationAssignPointController : Controller
    {
        // GET: LocationAssignPoint
        [Authorize]
        public ActionResult Index()
        {
            return View("~/views/LocationAssignPoint.cshtml");
        }

        [HttpGet]
        public ActionResult DisplayLocationOnMap()
        {
            string strLong = Request["Long"];
            string strLat = Request["Lat"];
            string strName = Request["AppName"];
            ViewBag.Long = strLong;
            ViewBag.Lat = strLat;
            if (strName != null && strName != "")
                ViewBag.AppName = strName;
            return View("~/views/DisplayLocationOnMap.cshtml");
        }
    }
}