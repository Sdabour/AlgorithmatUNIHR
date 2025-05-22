using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpVision.HR.HRBusiness;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSBusiness;
using AlgorithmatMVC.Controllers.HRController;
namespace AlgorithmatMVC.Controllers.PLN
{
    public class TaskController : Controller
    {
        // GET: Task
        [Authorize]
        public ActionResult Index()
        {
            
            return View("~/views/PLN/TaskDisplay.cshtml");
        }
        [Authorize]
        public ActionResult AddEditTask(string strTemp)
        {
            ViewBag.CurrentTask = new TaskBiz();
            if (strTemp != null)
            {
                int intTemp = 0;
                int.TryParse(strTemp, out intTemp);
                TaskBiz objBiz = new TaskBiz(intTemp);
                ViewBag.CurrentTask = objBiz;

            }

            return View("~/views/PLN/TaskAddEdit.cshtml");
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddEdit()
        {

            TaskBiz objTaskBiz = new TaskBiz();
            int intTemp = 0;
            string strTemp = "";
            objTaskBiz.ShortDesc = Request.Form["txtShortDesc"];
            objTaskBiz.Desc = Request.Form["txtDesc"];
            strTemp = Request.Form["cmbIterationType"];
            if (int.TryParse(strTemp, out intTemp))
                objTaskBiz.IterationType = (TaskIterationType)intTemp;
            strTemp = Request.Form["txtEstimatedPeriod"];
            double dblTemp = 0;
            if (int.TryParse(strTemp, out intTemp))
                objTaskBiz.EstimatedPeriod = intTemp;
            strTemp = Request.Form["cmbEstimatedPeriodType"];
            if(int.TryParse(strTemp,out intTemp))
            objTaskBiz.EstimatedPeriodType = (PeriodType)intTemp;
            // objTaskBiz.AssignedApplican
            //objTaskBiz.EmployeeAssigned =
            strTemp = "";
            strTemp = Request.Form["lblEmployeeValue"];
            if (strTemp != "")
            {

              SharpVision.UMS.UMSBusiness.EmployeeSimpleBiz objEmployee = (SharpVision.UMS.UMSBusiness.EmployeeSimpleBiz)Newtonsoft.Json.JsonConvert.DeserializeObject(strTemp);
                objTaskBiz.AssignedApplicantID = objEmployee.ID;

            }
            return View("~/views/PLN/TaskDisplay.cshtml");
        }

    }
}