using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpVision.HR.HRBusiness;
namespace AlgorithmatMVC.Controllers.HRController
{
    public class EstimationStatementSearchController : Controller
    {
        // GET: EstimationStatementSearch
        public ActionResult Index()
        {
            EstimationStatementCol objCol = new EstimationStatementCol();
            Session["EstimationStatementCol"] = objCol;
            return View("EstimationStatementSearch");

        }
        [HttpPost]
        public ActionResult ReturnWithResult()
        {
            EstimationStatementCol objCol;
            if (Session["EstimationStatementCol"] != null)
            {
                objCol = (EstimationStatementCol)Session["EstimationStatementCol"];
            }
            else
                objCol = new EstimationStatementCol();
            string strTemp = Request.Form["rdSelected"];
            if (strTemp != null && strTemp != ""&& objCol[strTemp]!= null)
            {
                EstimationStatementBiz objBiz = objCol[strTemp];
                Session["StatementBiz"] = objBiz;
            }
            return View("~/views/ApplicantWorkerEstimationSearch/ApplicantWorkerEstimationSearch.cshtml");
        }
    }
}