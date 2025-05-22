using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpVision.HR.HRBusiness;
using SharpVision.UMS.UMSBusiness;
using AlgorithmatMVC.Controllers.HRController;
namespace AlgorithmatMVC.Controllers.HRController
{
    public class HandShakeWebController : Controller
    {
        // GET: HandShakeWeb
        public ActionResult Index()
        {
            ApplicantHandShakeCol objCol = new ApplicantHandShakeCol(true);
            Session["HandShakeCol"] = objCol;
            return View("HandShaKeSearch");
        }
        [HttpPost]
        public ActionResult Search()
        {
            string strTemp = "";
            strTemp = Request.Form["dtStartDate"];

            DateTime dtStart = DateTime.Now;
            bool blIsDateRange = false;
            blIsDateRange= DateTime.TryParse(strTemp, out dtStart);

            strTemp = Request.Form["dtEndDate"];
           
            DateTime dtEnd = DateTime.Now;
            blIsDateRange &= DateTime.TryParse(strTemp, out dtEnd);
            EmployeeSimpleBiz objEmployee = new EmployeeSimpleBiz();
            strTemp = Request.Form["lblEmployeeValue"];
           
            int intTemp = 0;
            if (strTemp != "")
            {
                 dynamic objTemp = Newtonsoft.Json.JsonConvert.DeserializeObject(strTemp);
               strTemp = objTemp["ID"];
                int.TryParse(strTemp, out intTemp);

                objEmployee.ID = intTemp;
              

            }
            int intOnlineStatus = 0;
            strTemp = Request.Form["rdOnline"];
            int.TryParse(strTemp, out intOnlineStatus);
            string strApplicantIDs = Request.Form["lblApplicantIDs1"];
            if (!ApplicantHandShakeBiz.UMSHandShakeSearchAllAuthorized && strApplicantIDs == "")
                strApplicantIDs = "-55";
            if (ApplicantHandShakeBiz.UMSHandShakeSearchAllAuthorized && strApplicantIDs != "")
                strApplicantIDs = "";
            ApplicantHandShakeCol objCol = new ApplicantHandShakeCol(intOnlineStatus,strApplicantIDs,objEmployee.ID, blIsDateRange, dtStart, dtEnd);
            Session["HandShakeCol"] = objCol;
            return View("HandShaKeSearch");
        }
        public ActionResult DisplayDetails()
        {
            int intAppID = 0;
            string strApp = Request["App"];
            int.TryParse(strApp, out intAppID);
            ViewBag.AppID = intAppID;
            return View("HandShaKeDisplay");
        }

        public ActionResult HandShakeOnline()
        {
         
            return View("HandShaKeOnline");
        }
    }
}