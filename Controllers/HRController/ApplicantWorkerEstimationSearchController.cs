using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlgorithmatMVC.Controllers.HRController
{
    public class ApplicantWorkerEstimationSearchController : Controller
    {
        // GET: ApplicantWorkerEstimationSearch
       
        public ActionResult Index()
        {
            string strTemp = Request["SectorID"];
            Session["SectorID"] = 0;
            if (strTemp != "")
            {
                int intSectorID = 0;
                int.TryParse(strTemp, out intSectorID);
                Session["SectorID"] = intSectorID;


            }
            return View("ApplicantWorkerEstimationSearch");
        }
    }
}