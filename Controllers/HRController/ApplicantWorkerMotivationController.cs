using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpVision.HR.HRBusiness;

namespace AlgorithmatMVC.Controllers.HRController
{
    public class ApplicantWorkerMotivationController : Controller
    {
        // GET: ApplicantWorkerMotivation
        public ActionResult Index()
        {

            return View("ApplicantWorkerMotivation");
        }
        public ActionResult MotivationSearch()
        {

            return View("ApplicantWorkerMotivationSearch");
        }
        [HttpPost]
        public ActionResult Upload()
        {
            string strCost = Request.Form["lblMotivationCostCenter"];
            MotivationCostCenterSimple objCostCenter = System.Web.Helpers.Json.Decode<MotivationCostCenterSimple>(strCost);
            return View("ApplicantWorkerMotivation");
        }
    }
}